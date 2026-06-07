using UnityEngine;

namespace NavKeypad
{
    public class KeypadInteractionFPV : MonoBehaviour
    {
        public float interactDistance = 6f;
        public Camera fpsCamera;
        private GameObject ultimoBotonApuntado;
        private Camera cam;
        private Color colorOriginal;
        
        private void Start()
        {
            cam= fpsCamera != null ? fpsCamera : Camera.main;
            Debug.Log("Camara asignada: " + cam.gameObject.name);
            //cam = GetComponent<Camera>();
            //if (cam == null)
            //    cam = Camera.main;
        }

        private void Update()
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * interactDistance, Color.red);

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, interactDistance, Physics.AllLayers, QueryTriggerInteraction.Collide))
            {
                GameObject objetoApuntado = hit.collider.gameObject;

                if (hit.collider.GetComponent<KeypadButton>() != null || hit.collider.GetComponentInParent<KeypadButton>() != null)
                {
                    if (ultimoBotonApuntado != objetoApuntado)
                    {
                        QuitarSeleccion();

                        ultimoBotonApuntado = objetoApuntado;
                        Renderer rend = ultimoBotonApuntado.GetComponent<Renderer>();
                        if (rend != null)
                        {
                            colorOriginal = rend.material.color;
                            rend.material.color = Color.yellow;
                        }
                    }

                }
                else
                {
                    QuitarSeleccion();
                }
            }

            else
            {
                QuitarSeleccion();
            }

            if (Input.GetMouseButtonDown(0))
            {
                if(ultimoBotonApuntado != null)
                {
                    KeypadButton btn = ultimoBotonApuntado.GetComponent<KeypadButton>();
                    if(btn == null)
                        btn = ultimoBotonApuntado.GetComponentInParent<KeypadButton>();
                    if(btn != null)
                    {
                        Debug.Log("Botón presionado:" + ultimoBotonApuntado.name);
                        btn.PressButton();
                    }

                }
                //Vector3 origin= cam.transform.position;
                //Vector3 direction = cam.transform.forward;

                //Debug.Log("Origen rayo:" + origin);
                //Debug.Log("Dirección rayo:" + direction);
                

                //if (Physics.Raycast(origin, direction, out RaycastHit hit, interactDistance,
                //    Physics.AllLayers, QueryTriggerInteraction.Collide))
                //{
                //    Debug.Log("Hit: " + hit.collider.gameObject.name);
                //    KeypadButton btn = hit.collider.GetComponent<KeypadButton>();
                //    if (btn == null)
                //        btn = hit.collider.GetComponentInParent<KeypadButton>();
                //    if (btn != null)
                //    {
                //        Debug.Log("Botón preisonado:"+hit.collider.gameObject.name);
                //        btn.PressButton();
                //    }
                        
                //}

            }
        }

        private void QuitarSeleccion()
        {
            if(ultimoBotonApuntado != null)
            {
                Renderer rend = ultimoBotonApuntado.GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material.color = colorOriginal;
                }
                ultimoBotonApuntado = null;
            }
        }
    }
}