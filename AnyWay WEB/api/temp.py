import sqlite3
import pygraphviz as pgv

conn = sqlite3.connect("maps.db")
cursor = conn.cursor()

cursor.execute("SELECT name FROM sqlite_master WHERE type='table';")
tables = [row[0] for row in cursor.fetchall()]

graph = pgv.AGraph(strict=False, directed=True)

for table in tables:
    graph.add_node(table)
    cursor.execute(f"PRAGMA foreign_key_list({table});")
    for fk in cursor.fetchall():
        graph.add_edge(table, fk[2])  # da tabella corrente a referenced_table

graph.layout(prog='dot')
graph.draw("schema.png")