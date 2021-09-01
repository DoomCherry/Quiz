using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame
{
    public class ContainerController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private QuizVariantAnswer variantAnswer;
        public QuizVariantAnswer VariantAnswer => variantAnswer;
        public CellContainer Cell { get; private set; }
        void Start()
        {

        }

        

        public void SetContainer(CellContainer cell)
        {
            _sprite.sprite = cell.Icon;
            _sprite.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, cell.DefaultRotate);
            this.Cell = cell;
        }

        
    }
}
