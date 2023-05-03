using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class PathFinding
{    

    private static int ManhattanEstimate(Vector3 node, Vector3 goal)
    {
        return (int) (Mathf.Abs(node.x - goal.x) +
            Mathf.Abs(node.y - goal.y) +
            Mathf.Abs(node.z - goal.z));
    }

    public static List<Vector3> aEst(Vector3 lugarAtual, Vector3 destino, Grid grid){
        List<Vector3> open = new List<Vector3>();
        HashSet<Vector3> closed = new HashSet<Vector3>();
        List<Vector3> walkable = grid.allPossible();
        List<Vector3> adj = new List<Vector3>();
        List<Vector3> nodeParents = new List<Vector3>();
        IDictionary<Vector3, int> f = new Dictionary<Vector3, int>();
        IDictionary<Vector3, int> h = new Dictionary<Vector3, int>();
        IDictionary<Vector3, int> g = new Dictionary<Vector3, int>();
        //IDictionary<Vector3, Vector3> nodeParents = new Dictionary<Vector3, Vector3>();

        open.Add(lugarAtual);
        foreach( Vector3 vertex in walkable ) {
            f.Add(new KeyValuePair<Vector3, int>(vertex, int.MaxValue));
            h.Add(new KeyValuePair<Vector3, int>(vertex, int.MaxValue));
            g.Add(new KeyValuePair<Vector3, int>(vertex, int.MaxValue));
            nodeParents.Add(new Vector3(0,0,0));
        }
        h[lugarAtual] = ManhattanEstimate(lugarAtual, destino);
        f[lugarAtual] = g[lugarAtual] = 0;

        // Percorrer a lista de vértices que tem potencial para ser parte do caminho para achar o que tem
        // a menor distância de f
        while( open.Count > 0 ) {
            Vector3 iterado = open[0];
            
            // Encontrar o vértice que tem a menor distância f, e para desempatar utiliza o h que é o valor da heurística
            for( int i = 1; i < open.Count; i++ ) {
                    
                if( f[open[i]] < f[iterado] || f[open[i]] == f[iterado] ){
                    if( h[open[i]] < h[iterado] ) {
                        iterado = open[i];
                    }
                }
            }

            // Remove o vértice de menor distância atual da lista de vértices que já teve as distâncias calculadas
            open.Remove(iterado);
            // Adiciona o vértice de menor distância atual que já foi analisado e totalmente visitado
            closed.Add(iterado);

            // Se o vértice de menor distância atual for igual ao destino, se encerra a busca pelo menor caminho
            if( iterado == destino ) { 
                return RetracePath( lugarAtual, destino, nodeParents, walkable );
            }
            // adj recebe os vértices vizinhos do vértice atual
            adj = grid.findNeighbor(iterado);
            // Para cada vértice da lista de adjacencia
            foreach ( Vector3 n in adj ) {
                
                // Caso o vértice esteja na lista de vértices já analisados e totalmente visitados, passa para
                // o próximo vértice da lista de adjacencia, se houver
                if( closed.Contains(n) ) {
                    continue;
                }

                // Calcula a distância f somando a distância do vértice atual do ponto de partida + 
                // a distância calculada pela heurística
                int newCost = g[iterado] + ManhattanEstimate(iterado, n);
                // Se a distância resultado da soma for menor que a distância do vértice atual até o ponto de partida
                // OU o vértice atual da lista de adjacência não estiver na lista de vértices que precisam ter as distâncias calculadas
                if( newCost < g[n] || !open.Contains(n) ) {
                    // Adiciona em g a distância resultado da soma do vértice atual da lista de adjacência
                    g[n] = newCost;
                    // Adiciona em h a distância calculada pela heurística do vértice atual da lista de adjacência até o destino
                    h[n] = ManhattanEstimate(n, destino);
                    // O pai do vértice atual da lista de ajdcência é o vértice atual de menor distância de f
                    int index = indexOf(walkable, n);
                    nodeParents[index] = iterado;
                    
                    // Caso o vértice atual da lista de adjcência não esteja na lista de vértices de open, ele será adicionado
                    if ( !open.Contains(n) ) {
                        open.Add(n);
                    }
                }
            }
        }

        return null;
    }


    static List<Vector3> RetracePath(Vector3 start, Vector3 end, List<Vector3> nodeParents, List<Vector3> list ) {
        List<Vector3> resp = new List<Vector3>();
        Vector3 current = end;

        while ( current != start ) {
            resp.Add(current);
            int index = indexOf(list, current);
            current = nodeParents[index];
        }
        
        resp.Reverse();
        return resp;
    }


    static int indexOf(List<Vector3> list, Vector3 element) {
        int resp = -1;
        foreach( Vector3 el in list ){
            resp++;
            if (el == element) break;
        }

        return resp;
    }

    public static List<Vector3> buscaLargura(Vector3 lugarAtual, Vector3 destino, Grid grid) {
        // Fila para caminhamento com busca em largura
        List<Vector3> fila = new List<Vector3>();
        // Menor caminho para percorrer
        List<Vector3> menorCaminho = new List<Vector3>();
        // Posicao Removida
        Vector3 removido;
        // Posicoes possíveis adjacentes
        List<Vector3> adj = new List<Vector3>();
        // Todos os vértices visitados
        List<Vector3> verticesVisit = new List<Vector3>();
        // Quantidade de vértices na lista de adjacência
        int quant = 0;
        // Tupla com informação de parentes dos vértices
        IDictionary<Vector3, Vector3> nodeParents = new Dictionary<Vector3, Vector3>();

        // Adicionar posição em que a IA está atualmente
        fila.Add(lugarAtual);
        // Adicionar vértice na lista de vértice visitados
        verticesVisit.Add(lugarAtual);

        // Enquanto fila não estiver vazia
        while(fila.Count != 0) {
            removido = fila.First();

            // Remover vértice da primeira posição da lista
            fila.RemoveAt(0);

            // Formar lista de adjacência do vértice removido
            adj = grid.findNeighbor(removido);

            // Se o vértice removido for o meu destino paro o while
            if (removido == destino) {
                fila.Clear();
            }
            // Adicionar vértices não visitados da lista de adjacência do vértice
            foreach(Vector3 node in adj){
                // Verificar se o vértice já foi visitado
                if ( ! verticesVisit.Contains(node)) {
                    // Adicionar como vértice visitado
                    verticesVisit.Add(node);
                    // Adicionar vértice na fila para caminhamento
                    fila.Add(node);
                    // Adicionar filho e pai
                    nodeParents.Add(node, removido); 
                }
            }
        }
        // Encontrar no nodeParets o menor caminho
        Vector3 aux = nodeParents[destino];

        // Adicionar a posição destino
        menorCaminho.Add(destino);
        // Adicionar pai em menorCaminho
        menorCaminho.Add(aux);

        // Enquanto o vértice procurado for diferente da posição que a IA saiu para buscar a letra
        while (aux != lugarAtual) {
            // Encontrar pai do vértice em aux
            aux = nodeParents[aux];
            // Adicionar pai em menorCaminho
            menorCaminho.Add(aux);
        }
        // Como começou a adicionar a última posição no início, é necessário reverse
        menorCaminho.Reverse();

        return menorCaminho;
    }
}
