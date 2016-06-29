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
        private Node _vertexNode;
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
            });
            AllowAddNodeCommand = new DelegateCommand(() =>
            {
                IsTappedEnableProperty = !IsTappedEnableProperty;
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
            });
            ManipulationDeltaRelayCommand = new RelayCommand<Node>(node =>
            {
                OnPropertyChanged(nameof(EditNode));
            });
            ManipulationCompletedRelayCommand = new RelayCommand(() =>
            {
                OnPropertyChanged(nameof(EasyGraph));
            });
            DeleteNodeCommand = new RelayCommand<Node>((node) =>
            {
                EasyGraph.RemoveNode(node.NodeId);
                OnPropertyChanged(nameof(EasyGraph));
            });
            OpenEditNodePanelRelayCommand = new RelayCommand<Node>((node) =>
            {
                Width = 150;
                EditNode = EasyGraph.FindByValue(node.NodeId);
            });
            CloseEditNodePanelRelayCommand = new RelayCommand(() =>
            {
                Width = 0;
            });
            EditNodeRelayCommand = new RelayCommand(() =>
            {
                OnPropertyChanged(nameof(EasyGraph));
            });
            EdgeVertexNodeRelayCommand = new RelayCommand<Node>((node) =>
            {
                VertexNode = node;
                AddEdgeFlyoutProperty = true;
            });
            AddEdgeUndirectRelayCommand = new RelayCommand<Node>((node) =>
            {
                EasyGraph.AddUndirectedEdge(VertexNode.NodeId, node.NodeId);
                AddEdgeFlyoutProperty = false;
                OnPropertyChanged(nameof(EasyGraph));
            });
            AddEdgeDirectRelayCommand = new RelayCommand<Node>((node) =>
            {
                EasyGraph.AdDirectedEdge(VertexNode.NodeId, node.NodeId);
                AddEdgeFlyoutProperty = false;
                OnPropertyChanged(nameof(EasyGraph));
            });
        }

        public DelegateCommand IsOpenSpitViewPanel { get; private set; }
        public DelegateCommand AllowAddNodeCommand { get; private set; }
        public DelegateCommand DeleteGraphCommand { get; private set; }
        public DelegateCommand DisabledDelegateCommand { get; private set; }


        public RelayCommand<Node> DeleteNodeCommand { get; private set; }
        public RelayCommand<Node> AddNodeRelayCommand { get; private set; }
        public RelayCommand<Node> OpenEditNodePanelRelayCommand { get; private set; }
        public RelayCommand CloseEditNodePanelRelayCommand { get; private set; }
        public RelayCommand<Point> PointCursoRelayCommand { get; private set; }
        public RelayCommand<Node> ManipulationDeltaRelayCommand { get; }
        public RelayCommand ManipulationCompletedRelayCommand { get; }
        public RelayCommand EditNodeRelayCommand { get; }
        public RelayCommand<Node> EdgeVertexNodeRelayCommand { get; }
        public RelayCommand<Node> AddEdgeUndirectRelayCommand { get; }
        public RelayCommand<Node> AddEdgeDirectRelayCommand { get; }

        public Graph EasyGraph { get; set; }
        public Node VertexNode
        {
            get { return _vertexNode; }
            set { SetProperty(ref _vertexNode, value); }
        }
        public double Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }
        public Node EditNode
        {
            get { return _editNode; }
            set { SetProperty(ref _editNode, value); }
        }
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
