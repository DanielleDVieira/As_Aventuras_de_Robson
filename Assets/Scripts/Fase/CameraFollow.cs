using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Camera camera;
    // Posição do target, nesse caso, nosso player
    public Transform target;
    // Offset necessário para setar o eixo Z da câmera
    public Vector3 offset;
    // Valores mínimos e máximo que definirão o limite da câmera
    public Transform maxCimaEsquerdo, maxCimaDireito, maxBaixoEsquerdo, maxBaixoDireito;
    // Quando será a suavidade da transição da câmera
    [Range(1,10)] 
    public float smoothFactor;


    private void FixedUpdate(){
        Follow();
    }

    // Função que pegará a posição do target, adicionará o offset e a suavização 
    // Será levado em conta o BOUND da câmera, ou seja, o limite até onde a câmera pode mostrar
    void Follow(){
        Vector3 targetPosition = target.position + offset;

        float camSize = camera.orthographicSize;
        float camHeight = (camSize * 2f);
        float camWidth = (camera.aspect * camHeight);

             

        Vector3 boundPosition = new Vector3 ( 
            Mathf.Clamp(targetPosition.x, maxCimaEsquerdo.position.x + (camWidth / 2), maxCimaDireito.position.x - (camWidth / 2)),
            Mathf.Clamp(targetPosition.y, maxBaixoEsquerdo.position.y + (camHeight / 2), maxCimaEsquerdo.position.y - (camHeight / 2)),
            -10
        );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

}
