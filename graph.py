graph = { "a" : ["c"],
          "b" : ["c", "e"],
          "c" : ["a", "b", "d", "e"],
          "d" : ["c"],
          "e" : ["c", "b"],
          "f" : []
        }

def exist_path(graph, start, end):
    for neighbor in graph[start]:
        if neighbor == end:
            return "A path exists"
        else:
            for neighbor in graph[start]:
                return exist_path(graph, neighbor, end)
                
print(exist_path(graph, "a", "d"))
