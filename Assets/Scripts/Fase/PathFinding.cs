using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class PathFinding
{    
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

            Debug.Log("Removido: " + removido);
            // Remover vértice da primeira posição da lista
            fila.RemoveAt(0);

            // Formar lista de adjacência do vértice removido
            adj = grid.findNeighbor(removido);

            // Se o vértice removido for o meu destino paro o while
            if (removido == destino) {
                fila.Clear();
            } else {
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
        }

        Debug.Log("Vim no dicionário");
        // Encontrar no nodeParets o menor caminho
        Vector3 aux = nodeParents[destino];

        // Adicionar a posição destino
        menorCaminho.Add(destino);

        // Enquanto o vértice procurado for diferente da posição que a IA saiu para buscar a letra
        while (aux != lugarAtual) {
            // Encontrar pai do vértice em aux
            aux = nodeParents[aux];
            // Adicionar pai em menorCaminho
            menorCaminho.Add(aux);
        }

        // Como começou a adicionar a última posição no início, é necessário reverse
        menorCaminho.Reverse();

        Debug.Log("Menor caminho:");
        foreach(Vector3 node in menorCaminho){
            Debug.Log(node);
        }

        return menorCaminho;
    }
}
