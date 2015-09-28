using System;

namespace SeminarioDeEstructurasII {
    public class Edge<T> {

        Node<T> from;
        Node<T> to;
        double edgeWeight;
        bool edgeIsDirected;

        public Edge(Node<T> fromNode, Node<T> toNode, bool isDirected) : this(fromNode, toNode, 0, isDirected) { }

        public Edge(Node<T> fromNode, Node<T> toNode, double weight, bool isDirected) {
            if (fromNode == null) {
                throw new ArgumentNullException("fromNode");
            }

            if (toNode == null) {
                throw new ArgumentNullException("toNode");
            }

            from = fromNode;
            to = toNode;
            edgeWeight = weight;
            edgeIsDirected = isDirected;
        }

        public Node<T> FromNode {
            get {
                return from;
            }
        }

        public Node<T> ToNode {
            get {
                return to;
            }
        }

        public bool IsDirected {
            get {
                return edgeIsDirected;
            }
        }

        public double Weight {
            get {
                return edgeWeight;
            }
        }

        public Node<T> GetPartnerNode(Node<T> Node) {
            if (from == Node) {
                return to;
            } else if (to == Node) {
                return from;
            } else {
                throw new ArgumentException("Node");
            }
        }
    }
}

