using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame
{
    public class ContainerController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private SpriteRenderer background;
        void Start()
        {

        }

        public void SetContainer(CellContainer cell)
        {
            sprite.sprite = cell.icon;
            sprite.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, cell.defaultRotate);
        }
    }
}
