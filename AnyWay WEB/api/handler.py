import sqlite3

# Percorso al tuo database SQLite
db_path = "maps.db"

# Connessione al database
conn = sqlite3.connect(db_path)
cursor = conn.cursor()

# Disabilita temporaneamente i vincoli di chiave esterna
cursor.execute("PRAGMA foreign_keys = OFF;")

# Recupera tutte le tabelle (escludendo le tabelle di sistema)
cursor.execute("SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';")
tables = cursor.fetchall()

# Elimina tutti i dati da ciascuna tabella
for table_name in tables:
    cursor.execute(f'DELETE FROM "{table_name[0]}";')

# Riabilita i vincoli di chiave esterna
cursor.execute("PRAGMA foreign_keys = ON;")

# Salva le modifiche
conn.commit()

# Chiudi la connessione
conn.close()

print("Database svuotato senza cambiare la struttura!")
