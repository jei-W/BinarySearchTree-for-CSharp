using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        //1. 처음 rootnode는 null이다.

        //3. 삽입할 때, 트리의 재배치는 하지 않는다.
        //4. 삭제할 때만 트리의 재배치를 수행한다.
        //5. 트리안에 데이터를 전체 출력할 수 있어야 한다

        Node rootNode = null;
        Node node;

        void Insert( int value )
        {
            Node valueNode = new Node(value);

            //2. 첫 삽입에 root node가 null이면 루트 노드를 생성한다
            if( rootNode == null )
            {
                rootNode = valueNode;
            }
            else
            {
                node = rootNode;
                CheckPosition();
            }

            void CheckPosition()
            {
                if( valueNode < node )
                {
                    Node parents = node;
                    node = node.GetLeft();
                    node.SetParents(node);

                    if( node == null )
                    {
                        node = valueNode;
                    }
                    else
                    {
                        CheckPosition();
                    }
                }

                else if( valueNode > node )
                {
                    node.SetParents(node);
                    node = node.GetRight();

                    if( node == null )
                    {
                        node = valueNode;
                    }
                    else
                    {
                        CheckPosition();
                    }
                }
            }
        }

        void Remove( int value )
        {

        }

        void Print()
        {

        }

        void Find( int value )
        {

        }
    }
}
