using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using MyToolkit.Command;
using Prism.Commands;
using SupperGraph.Models;

namespace SupperGraph.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _isPaneOpenProperty;
        private Point _pointCursor;
        private bool _isTappedEnableProperty;
        private Node _editNode;
        private double _width;
        private bool _addEdgeFlyoutProperty;
       
        public MainPageViewModel()
        {
            EasyGraph = new Graph();

            PointCursoRelayCommand = new RelayCommand<Point>(point =>
            {
                PointCursor = point;
            });
            IsOpenSpitViewPanel = new DelegateCommand(() =>
            {
                IsPaneOpenProperty = !IsPaneOpenProperty;
            });
            DisabledDelegateCommand = new DelegateCommand(() =>
            {
                IsTappedEnableProperty = false;
                AddEdgeFlyoutProperty = false;
                AllowAddEdge = false;
                EdgeNode = null;
                VertexNode = null;
            });
            AllowAddNodeCommand = new DelegateCommand(() =>
            {
                IsTappedEnableProperty = true;
                AllowAddEdge = false;
            });
            DeleteGraphCommand = new DelegateCommand(() =>
            {
                EasyGraph.DeleteGraph();
                OnPropertyChanged(nameof(EasyGraph));
            });
            AddNodeRelayCommand = new RelayCommand<Node>(node =>
            {
                EasyGraph.Nodes.Add(node);
                OnPropertyChanged(nameof(EasyGraph));
            }, node => IsTappedEnableProperty);
            ManipulationCompletedRelayCommand = new RelayCommand(() =>
            {
                OnPropertyChanged(nameof(EasyGraph));
                OnPropertyChanged(nameof(EditNode));
            });
            DeleteNodeCommand = new RelayCommand<Node>((node) =>
            {
                EasyGraph.RemoveNode(node.NodeId);
                OnPropertyChanged(nameof(EasyGraph));
            });
            OpenEditNodePanelRelayCommand = new RelayCommand<Node>((node) =>
            {
                Width = 150;
                EditNode = EasyGraph.Nodes.First(m => m.NodeId == node.NodeId);
                OnPropertyChanged(nameof(EditNode));

            });
            CloseEditNodePanelRelayCommand = new RelayCommand(() =>
            {
                Width = 0;
            });
            EditNodeRelayCommand = new RelayCommand(() =>
            {
                OnPropertyChanged(nameof(EasyGraph));
                
            });
            AddEdgeVertexFlyoutRelayCommand = new RelayCommand<Node>((node) =>
            {
                VertexNode = node;
                AddEdgeFlyoutProperty = true;
            });
            AddUndirectEdgeFlyoutRelayCommand = new RelayCommand<Node>((node) =>
            {
                EasyGraph.AddUndirectedEdge(VertexNode.NodeId, node.NodeId);
                AddEdgeFlyoutProperty = false;
                OnPropertyChanged(nameof(EasyGraph));
            });
            AddDirectEdgeFlyoutRelayCommand = new RelayCommand<Node>((node) =>
            {
                EasyGraph.AdDirectedEdge(VertexNode.NodeId, node.NodeId);
                AddEdgeFlyoutProperty = false;
                OnPropertyChanged(nameof(EasyGraph));
            });
            AddEdgeDelegateCommand = new RelayCommand<Node>( node =>
            {
                if (EdgeNode == null)
                {
                    EdgeNode = node;
                }
                else
                {
                    if (ChooseDirectOrUndirectEdge == true)
                    {
                        EasyGraph.AdDirectedEdge(EdgeNode.NodeId, node.NodeId);
                    }
                    else
                    {
                        EasyGraph.AddUndirectedEdge(EdgeNode.NodeId, node.NodeId);
                    }
                    EdgeNode = null;
                    OnPropertyChanged(nameof(EasyGraph));
                }
            }, node => AllowAddEdge);
            AllowAddDirectEdgeCommand = new DelegateCommand(() =>
            {
                AllowAddEdge = true;
                IsTappedEnableProperty = false;
                ChooseDirectOrUndirectEdge = true;
            });
            AllowAddUndirectEdgeCommand = new DelegateCommand(() =>
            {
                ChooseDirectOrUndirectEdge = false;
                IsTappedEnableProperty = false;
                AllowAddEdge = true;
            });
        }

        public DelegateCommand IsOpenSpitViewPanel { get; private set; }
        public DelegateCommand AllowAddNodeCommand { get; private set; }
        public DelegateCommand DeleteGraphCommand { get; private set; }
        public DelegateCommand DisabledDelegateCommand { get; private set; }
        public RelayCommand<Node> AddEdgeDelegateCommand { get; private set; }
        public DelegateCommand AllowAddDirectEdgeCommand { get; private set; }
        public DelegateCommand AllowAddUndirectEdgeCommand { get; private set; }

        public RelayCommand<Node> DeleteNodeCommand { get; private set; }
        public RelayCommand<Node> AddNodeRelayCommand { get; private set; }
        public RelayCommand<Node> OpenEditNodePanelRelayCommand { get; private set; }
        public RelayCommand CloseEditNodePanelRelayCommand { get; private set; }
        public RelayCommand<Point> PointCursoRelayCommand { get; private set; }
        public RelayCommand ManipulationCompletedRelayCommand { get; }
        public RelayCommand EditNodeRelayCommand { get; }
        public RelayCommand<Node> AddEdgeVertexFlyoutRelayCommand { get; }
        public RelayCommand<Node> AddUndirectEdgeFlyoutRelayCommand { get; }
        public RelayCommand<Node> AddDirectEdgeFlyoutRelayCommand { get; }

        private Node EdgeNode { get; set; } = null;
        public Graph EasyGraph { get; set; }
        private Node VertexNode { get; set; } = null;
        public bool AllowAddEdge { get; set; } = false;
        private bool ChooseDirectOrUndirectEdge { get; set; }
        public double Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }

        public Node EditNode
        {
            get
            {
                return _editNode;
            }
            set
            {
                _editNode = value;
                OnPropertyChanged(nameof(EditNode));
            }
        }
        //{
        //    get { return _editNode; }
        //    set { SetProperty(ref _editNode, value); }
        //}
        public bool IsPaneOpenProperty
        {
            get { return _isPaneOpenProperty; }
            set { SetProperty(ref _isPaneOpenProperty, value); }
        }
        public Point PointCursor
        {
            get { return _pointCursor; }
            set { SetProperty(ref _pointCursor, value); }
        }
        public bool IsTappedEnableProperty
        {
            get { return _isTappedEnableProperty; }
            set { SetProperty(ref _isTappedEnableProperty, value); }
        }
        public bool AddEdgeFlyoutProperty
        {
            get { return _addEdgeFlyoutProperty; }
            set { SetProperty(ref _addEdgeFlyoutProperty, value); }
        }
    }
}
