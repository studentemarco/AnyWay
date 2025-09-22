'''
Il programma, data una mappa (grafo) di punti, partenza A e destinazione B, fornisce il percorso minimo da A a B.

La mappa di punti deve contenente una lista archi. Ogni arco è rappresentato da una tupla (start, end, weight):
[
    (pointA, pointB, weight)
    ...
]

Il programma restituira' una lista di identificatori dei punti da percorrere (in ordine) per arrivare a destinazione.

'''

import json
from models import arc
import networkx as nx

def ShortestPath(graph, start, destination):
    try:
        if not isinstance(graph, nx.Graph) and not isinstance(graph, nx.DiGraph):
            raise ValueError
        # Calcola il percorso minimo e il suo costo utilizzando Dijkstra
        path = nx.dijkstra_path(graph, source=start, target=destination, weight='weight')
        return path
    except nx.NetworkXNoPath:
        raise AttributeError("Non esiste un percorso che collega questi 2 punti") 
    except nx.NodeNotFound:
        raise AttributeError(f"Partenza'{start}' e/o Destinazione '{destination}' non trovato/i")
    except ValueError:
        raise ValueError("Invalid Graph")
 

class Graph:
    def __init__(self, directed = True):
        self._map = []
        self._GMap = nx.Graph()
        if directed:
            self._GMap = nx.DiGraph()
    
    def __str__(self):
        temp = ""
        for u, v, data in self._GMap.edges(data=True):
            temp += f"Arco tra {u} e {v} con peso {data['weight']}\n "

        return f"Nodi del grafo:  {self._GMap.nodes()} \n Archi del grafo: \n {temp}"
    def MakeMap(self, data): #Genera una mappa a partire da una lista di archi (data)
        '''
        Generate a graph from a list of arc "data":
        [
            (pointA, pointB, weight)
            ...
        ]
        Warning: if the graph is directed, an arc from A to B won't be automatically defined for B to A.
        '''
        for a in data:
            Arc = arc.Arc(a[0], a[1], a[2])
            self._map.append(Arc)

        for a in self._map:
            self._GMap.add_edge(a.pointA, a.pointB, weight = a.weight)
        
    def loadMapJson(self, pathname): #Genera una mappa a partire da un Json
        try:
            with open(pathname, 'r') as file:
                data = json.load(file)
                self.MakeMap(data)
        except json.JSONDecodeError:
            return {"error": "Invalid JSON file"}

    def showMap(self): #Visualizza a schermo la mappa
        print(self.__str__())

    def Travel(self, start, destination):
        return ShortestPath(self._GMap, start, destination)     