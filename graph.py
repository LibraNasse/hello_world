graph = { "a" : ["c"],
          "b" : ["c", "e"],
          "c" : ["a", "b", "d", "e"],
          "d" : ["c"],
          "e" : ["c", "b"],
          "f" : []
        }

def exist_path(graph, a, b):
    for neighbor in graph[a]:
        if neighbor == b:
            return "A path exists"
        else:
            for neighbor in graph[a]:
                return exist_path(graph, neighbor, b)
                
print(exist_path(graph,"a","d"))
