using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] armas;    // armas en el inspector
    private bool abierto = false; // Esto es pa que no se abra mas de una vez

    private void OnTriggerEnter(Collider other)
    {
        if (!abierto && other.CompareTag("Player"))
        {
            DarArmaAleatoria(other.gameObject);
            abierto = true;
            Debug.Log("Cofre abierto");
        }
    }

    void DarArmaAleatoria(GameObject jugador)
    {
        int numero = Random.Range(0, armas.Length);  
        GameObject armaElegida = Instantiate(armas[numero]);

        // Hace que el arma aparezca como hijo del plaier
        armaElegida.transform.SetParent(jugador.transform);
        armaElegida.transform.localPosition = Vector3.zero;   

        Debug.Log("Arma obtenida: " + armaElegida.name);
    }
}
