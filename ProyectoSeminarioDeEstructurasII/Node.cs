using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SeminarioDeEstructurasII {
    public class Node<T> {
        private T nodeData;
        private List<Edge<T>> incidentEdges;
        private List<Edge<T>> emanatingEdges;

        public Node(T data) {
            nodeData = data;
            incidentEdges = new List<Edge<T>>();
            emanatingEdges = new List<Edge<T>>();
        }

        public T Data {
            get {
                return nodeData;
            }
            set {
                nodeData = value;
            }
        }

        public int IncidentEdgesCount {
            get {
                return incidentEdges.Count;
            }
        }

        public int Degree {
            get {
                return emanatingEdges.Count;
            }
        }

        public IEnumerator<Edge<T>> IncidentEdges {
            get {
                return incidentEdges.GetEnumerator();
            }
        }

        public IEnumerator<Edge<T>> EmanatingEdges {
            get {
                return emanatingEdges.GetEnumerator();
            }
        }

        public bool HasEmanatingEdgeTo(Node<T> toNode) {
            for (int i = 0; i < emanatingEdges.Count; i++) {
                if (emanatingEdges[i].IsDirected) {
                    if (emanatingEdges[i].ToNode == toNode) {
                        return true;
                    }
                } else {
                    if ((emanatingEdges[i].ToNode == toNode) ||
                        ((emanatingEdges[i].FromNode == toNode))) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasIncidentEdgeWith(Node<T> fromNode) {
            for (int i = 0; i < incidentEdges.Count; i++) {
                if ((incidentEdges[i].FromNode == fromNode) ||
                    (incidentEdges[i].ToNode == fromNode)) {
                    return true;
                }
            }

            return false;
        }

        public Edge<T> GetEmanatingEdgeTo(Node<T> toNode) {
            for (int i = 0; i < emanatingEdges.Count; i++) {
                if (emanatingEdges[i].IsDirected) {
                    if (emanatingEdges[i].ToNode == toNode) {
                        return emanatingEdges[i];
                    }
                } else {
                    if ((emanatingEdges[i].FromNode == toNode) ||
                        (emanatingEdges[i].ToNode == toNode)) {
                        return emanatingEdges[i];
                    }
                }
            }

            return null;
        }

        public Edge<T> GetIncidentEdgeWith(Node<T> toNode) {
            for (int i = 0; i < incidentEdges.Count; i++) {
                if ((incidentEdges[i].ToNode == toNode) ||
                    (incidentEdges[i].FromNode == toNode)) {
                    return incidentEdges[i];
                }
            }

            return null;
        }

        internal List<Edge<T>> IncidentEdgeList {
            get {
                return incidentEdges;
            }
        }

        internal List<Edge<T>> EmanatingEdgeList {
            get {
                return emanatingEdges;
            }
        }

        internal void RemoveEdge(Edge<T> edge) {

            Debug.Assert(edge != null);

            RemoveEdgeFromNode(edge);
        }

        internal void AddEdge(Edge<T> edge) {

            Debug.Assert(edge != null);

            if (edge.IsDirected) {
                if (edge.FromNode == this) {
                    emanatingEdges.Add(edge);
                }
            } else {
                emanatingEdges.Add(edge);
            }

            incidentEdges.Add(edge);
        }

        void RemoveEdgeFromNode(Edge<T> edge) {

            Debug.Assert(incidentEdges.Remove(edge),
                "Edge not found on Node in RemoveEdgeFromNode.");

            incidentEdges.Remove(edge);

            if (edge.IsDirected) {
                if (edge.FromNode == this) {
                    emanatingEdges.Remove(edge);
                }
            } else {
                emanatingEdges.Remove(edge);
            }
        }
    }
}

