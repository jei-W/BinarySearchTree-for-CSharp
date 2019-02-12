﻿using System;
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

        public void Insert( int value )
        {
            Node newNode = new Node(value);

            //2. 첫 삽입에 root node가 null이면 루트 노드를 생성한다
            if( rootNode == null )
            {
                rootNode = newNode;
                return;
            }

            Node parentNode = FindParentNodeForInsert(rootNode);

            // 새로운 노드의 부모 셋팅
            newNode.SetParents(parentNode);

            if( parentNode < newNode )
                parentNode.SetRight(newNode);
            else
                parentNode.SetLeft(newNode);

            Node FindParentNodeForInsert( Node currentNode )
            {
                if( newNode < currentNode )
                {
                    if( currentNode.GetLeft() == null )
                    {
                        return currentNode;
                    }
                    else
                    {
                        return FindParentNodeForInsert(currentNode.GetLeft());
                    }
                }
                else if( newNode > currentNode )
                {
                    if( currentNode.GetRight() == null )
                    {
                        return currentNode;
                    }
                    else
                    {
                        return FindParentNodeForInsert(currentNode.GetRight());
                    }
                }

                return null; // 중복..일 때?
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
