//(function () {
    'use stric';

    //var app = angular.module('App', ['blockUI', 'ui.grid', 'ui.grid.pagination', 'ui.grid.autoResize', 'ui.grid.resizeColumns', 'ui.grid.exporter', 'ui.grid.selection', 'ui.grid.grouping', 'ui.grid.treeView', 'ui.grid.expandable', 'ui.tree','treeControl']);
    //var Obj;
    //var token = "";
    //var path = "";

var app = angular.module('App', ['blockUI', 'ui.grid', 'ui.grid.pagination', 'ui.grid.autoResize', 'ui.grid.resizeColumns', 'ui.grid.exporter', 'ui.grid.selection', 'ui.grid.grouping', 'ui.grid.treeView', 'ui.grid.expandable', 'ui.tree','treeControl']);
var Obj;
var token = "";
var path = "";
app.controller("CtrlGmuds", ['$scope', '$http', '$location', '$window', '$timeout', 'blockUI', 'uiGridConstants','uiGridGroupingConstants','uiGridTreeViewConstants','$interval',
function ($scope, $http, $location, $window, $timeout, blockUI, uiGridConstants, uiGridGroupingConstants, uiGridTreeViewConstants, $interval) {



   
            var vm = this

            Obj = $scope;

            path = window.location.origin;

        var grp = {}
        var ArquivosGmuds = { Ano: "", Numero: "", Descricao: "" }


        $scope.STATUS = "ONLINE";
        $scope.MENSAGEM = "DEKRA T.I";
        $scope.GmudTipe = ["LIBERAÇÃO EMERGENCIAL", "LIBELRAÇÃO"];
        $scope.NUMEROGMUD = ["ATUAL 1461", "1459", "1458"];

        $scope.TOTAL_A = 6
        $scope.TOTAL_F = 4

        $scope.data =  {
            model: null,
            availableOptions: [{ id: '1461', name: '1461' },
                               { id: '1460', name: '1460' },
                               { id: '1459', name: '1459' }]
        };

        $scope.SOLICITANTE = ["EDNILSON MARTINS", "VAMDERLEI SILVA"];
        $scope.DEPARTAMENTOSOLICITANTE = ["PROJETOS", "ADMINISTRATIVO","VENDAS"];

        $scope.number = "A";
                 

        $scope.treeOptions = {
            nodeChildren: "Itens",
            dirSelectable: true,
            injectClasses: {
                ul: "a1",
                li: "a2",
                liSelected: "a7",
                iExpanded: "a3",
                iCollapsed: "a4",
                iLeaf: "a5",
                label: "a6",
                labelSelected: "a8"
            }
        }

        $scope.Diretorios = function ()
            {
                //{ params: params.Model }
                //)

                var model = {};

                $http.get(path + "/home/Diretorios")
                             .then(function (request)
                             {
                                 var dados = request.data;

                                 //for (var i = 0; i < dados.length; i++)
                                 //{
                                 //    dados[i].$$treeLevel = 0
                                 //    var itenss = dados[i].Itens;

                                 //    for (var a = 0; a < itenss.length; a++)
                                 //    {
                                 //        dados[i].Itens[a].$$treeLevel = 0
                                 //    }

                                 //}

                                 //angular.forEach(dados, function (value, index)
                                 //{                            
                                 //    value.$$treeLevel = 0;
                                 //    value.Itens.$$treeLevel = 1;                            
                                 //}); 


                                 $scope.dataForTheTree = dados

                                 //$scope.gridPesq.data = [];
                                 //writeoutNode(dados, 0, $scope.gridPesq.data);



                             }).catch(function (request){
                                 console.log("Error" + request.message)
                             }).finally(function (request){                       
                                 blockUI.stop("Pesquisa Finalizada")
                             });
            };

        $scope.Diretorios();
        
        //$scope.dataForTheTree =
        //[
        //    { "name" : "Joe", "age" : "21", "children" : [ { "name" : "Smith", "age" : "42", "children" : [] },
        //    { "name" : "Gary", "age" : "21", "children" : [{ "name" : "Jenifer", "age" : "23", "children" : [{ "name" : "Dani", "age" : "32", "children" : [] },{ "name" : "Max", "age" : "34", "children" : [] } ]} ]}  ]},
        //    { "name" : "Albert", "age" : "33", "children" : [] },
        //    { "name" : "Ron", "age" : "29", "children" : [] }
        //]
    }]);

//}());


//})



//var app = angular.module('App', ['blockUI', 'ui.grid', 'ui.grid.pagination', 'ui.grid.autoResize', 'ui.grid.resizeColumns', 'ui.grid.exporter', 'ui.grid.selection', 'ui.grid.grouping', 'ui.grid.treeView', 'ui.grid.expandable', 'ui.tree']);
//var Obj;
//var token = "";
//var path = "";
//app.controller("CtrlGmuds", ['$scope', '$http', '$location', '$window', '$timeout', 'blockUI', 'uiGridConstants','uiGridGroupingConstants','uiGridTreeViewConstants','$interval',
//function ($scope, $http, $location, $window, $timeout, blockUI, uiGridConstants, uiGridGroupingConstants, uiGridTreeViewConstants, $interval) {

//    var vm = this

//    Obj = $scope;

//    path = window.location.origin;

//    $scope.Changing = function ($scope)
//    {
//        $scope.treedata = createSubTree(3, 4, "");

//        $scope.addRoot = function ()
//        {
//            $scope.treedata.push({ label: "New Root", id: "some id", children: [] })
//        };

//        $scope.addChildToSecondRoot = function ()
//        {
//            $scope.treedata[1].children.push({ label: "New Child", id: "some id", children: [] })
//        };
//    }

//    $scope.Changing();

//    //$scope.treeOptions = {
//    //    nodeChildren: "children",
//    //    dirSelectable: true,
//    //    injectClasses: {
//    //        ul: "a1",
//    //        li: "a2",
//    //        liSelected: "a7",
//    //        iExpanded: "a3",
//    //        iCollapsed: "a4",
//    //        iLeaf: "a5",
//    //        label: "a6",
//    //        labelSelected: "a8"
//    //    }
//    //}
//    //$scope.dataForTheTree =
//    //[
//    //    {
//    //        "name": "Joe", "age": "21", "children": [
//    //          { "name": "Smith", "age": "42", "children": [] },
//    //          {
//    //              "name": "Gary", "age": "21", "children": [
//    //                {
//    //                    "name": "Jenifer", "age": "23", "children": [
//    //                      { "name": "Dani", "age": "32", "children": [] },
//    //                      { "name": "Max", "age": "34", "children": [] }
//    //                    ]
//    //                }
//    //              ]
//    //          }
//    //        ]
//    //    },
//    //    { "name": "Albert", "age": "33", "children": [] },
//    //    { "name": "Ron", "age": "29", "children": [] }
//    //];

//    //var grp = {}
//    //var ArquivosGmuds = { Ano: "", Numero: "", Descricao: "" }
    
//    //var writeoutNode = function (childArray, currentLevel, dataArray)
//    //{
//    //    if (typeof childArray !== 'undefined')
//    //    {
//    //        childArray.forEach(function (childNode)
//    //        {
//    //            if (typeof childNode.Itens !== 'undefined')
//    //            {
//    //                if (childNode.Itens.length > 0) {
//    //                    //if(currentLevel>=1){
//    //                    //  currentLevel = currentLevel-1;
//    //                    //}
//    //                    childNode.$$treeLevel = currentLevel;
//    //                }
//    //            }
//    //            else
//    //            {
//    //                if (childNode.isChild) {
//    //                    //childNode.$$treeLevel = currentLevel
//    //                } else {
//    //                    childNode.$$treeLevel = -1;
//    //                }
//    //            }

//    //            dataArray.push(childNode);
//    //            writeoutNode(childNode.Itens, currentLevel + 1, dataArray);
//    //        });
//    //    }
//    //};

//    //$scope.gridPesq =
//    //{
//    //    enableScrollbars: false,
//    //    enableFiltering: true,
//    //    enableRowSelection: true,
//    //    //selectable: "row", columns: [{ field: "text", title: "Text" }, { field: "id", title: "Id" }],
//    //    paginationPageSizes: [25, 50, 75],
//    //    paginationPageSize: 25,
//    //    useExternalPagination: false,
//    //    useExternalSorting: false,     
//    //    enableColumnMenus: false,
//    //    //infiniteScrollDown: false,
//    //    paginationPageSize: 30,
//    //    rowHeight: 35,
//    //    enableGridMenu: false,
//    //    exporterMenuPdf: false,
//    //    exporterMenuCsv: false,
//    //    enableGridMenu: true,
//    //    enableSorting: true,
//    //    enableFiltering: true,
//    //    showTreeExpandNoChildren: true,

//    //    showTreeRowHeader: true,
//    //    enableRowHeaderSelection: true, // Display checkboxes on every row when it's true
        

//    //    columnDefs:
//    //    [
//    //         {
//    //             field: 'Ano',
//    //             name: 'Ano',
//    //             width: '80',
//    //             displayName: 'Ano',
//    //             headerCellClass: 'ui-grid-header-text',
//    //             cellClass: 'ui-grid-cell-contents',
//    //             enableFiltering: true,
//    //         },
//    //         {
//    //             field: 'id',
//    //             name: 'id',
//    //             width: '80',
//    //             displayName: 'id',
//    //             headerCellClass: 'ui-grid-header-text',
//    //             cellClass: 'ui-grid-cell-contents',
//    //             enableFiltering: true,
//    //         },
//    //         {
//    //             field: 'Descricao',
//    //             name: 'Descricao',
//    //             displayName: 'Descricao',
//    //             headerCellClass: 'ui-grid-header-text',
//    //             cellClass: 'ui-grid-cell-contents',
//    //             enableFiltering: true,
//    //         },
//    //          {
//    //              field: 'Arquivo',
//    //              name: 'Arquivo',
//    //              displayName: 'Arquivo',
//    //              headerCellClass: 'ui-grid-header-text',
//    //              cellClass: 'ui-grid-cell-contents',
//    //              enableFiltering: true,
//    //          },
            
//    //         //{ name: 'Itens', grouping: { groupPriority: 1 }, sort: { priority: 1, direction: 'asc' }, width: '20%', cellFilter: 'Itens' },
//    //         //{ name: 'age', treeAggregationType: uiGridGroupingConstants.aggregation.MAX, width: '20%' },
//    //         //{ field: '', cellTooltip: 'Arquivos SQL', width: "60", displayName: 'SQL', name: ' SQL ', enableFiltering: false, cellTemplate: '<div style="width: 28px; height: 28px; background: url(/images/Icons/PDF/PDF1.png); background-repeat: no-repeat; background-size: 100% 100%; margin: 6px 11px 1px 10px;cursor: pointer;" ng-click="grid.appScope.GridApp(grid, row)"></div>' },
//    //         //{ field: '', cellTooltip: 'Arquivo Docx', width: "60", displayName: 'DOCX', name: ' DOCX ', enableFiltering: false, cellTemplate: '<div style="width: 28px; height: 28px; background: url(/images/Icons/PDF/PDF2.png); background-repeat: no-repeat; background-size: 100% 100%;  margin: 6px 11px 1px 10px;cursor: pointer;" ng-click="grid.appScope.GridApp2(grid, row)"></div>' },
//    //         //{ field: '', cellTooltip: 'EDITAR O ARQUIVO WORD', width: "40", displayName: 'Edit', name: ' a ', enableFiltering: false, cellTemplate: '<div style="width: 28px; height: 28px; background: url(/images/Icons/PDF/PDF3.png); background-repeat: no-repeat; background-size: 100% 100%;  margin: 6px 11px 1px 10px;cursor: pointer;" ng-click="grid.appScope.GridApp2(grid, row)"></div>' },
//    //         //{ field: '', cellTooltip: 'VISUALIZAR ARQUIVO WORD', width: "40", displayName: 'View', name: ' B ', enableFiltering: false, cellTemplate: '<div style="width: 28px; height: 28px; background: url(/images/Icons/PDF/download.png); background-repeat: no-repeat; background-size: 100% 100%;  margin: 6px 11px 1px 10px;cursor: pointer;" ng-click="grid.appScope.GridApp2(grid, row)"></div>' },
            

//    //       //{ field: 'NrVoucher', name: 'NrVoucher', enableCellEditOnFocus: true, displayName: 'Numero do Voucher', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true, enableSorting: true },
//    //       //{ field: 'NrVistoria', width: "80", name: 'NrVistoria', displayName: 'Vistoria', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true, enableSorting: true },
//    //       //{ field: 'Placa', width: "80", name: 'Placa', displayName: 'Placa', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true, enableSorting: true },
//    //       //{ field: 'Chassi', name: 'Chassi', displayName: 'Chassi', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true, },
//    //       //{ field: 'DataHora', name: 'DataHora', displayName: 'Data da Finalização', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true, enableSorting: true },
//    //       //{
//    //       //    field: 'Status', visible: true, name: 'Status', displayName: 'Parecer', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true,
//    //       //    filter: {
//    //       //        type: uiGridConstants.filter.SELECT,
//    //       //        selectOptions: StatusOpcoes,
//    //       //        condition: function (term, value, row, column) {
//    //       //            if (row.entity.Status == term) {
//    //       //                return true;
//    //       //            }
//    //       //        },
//    //       //    }
//    //       //},
//    //       //{
//    //       //    field: 'Motivo',
//    //       //    cellTooltip: function (row, col) {
//    //       //        return 'Motivo: ' + row.entity.Motivo;
//    //       //    }, headerTooltip: function (col) {
//    //       //        return 'Header: ' + col.displayName;
//    //       //    }, name: 'Motivo', displayName: 'Motivo', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true
//    //       //},
//    //       //{ field: 'NomeCliente', visible: true, name: 'NomeCliente', displayName: 'Cliente', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true },
//    //       //{ field: 'CPF_CNPJ', visible: true, name: 'CPF_CNPJ', displayName: 'CPF/CNPJ', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true },
//    //       //{ field: 'ModeloVeiculo', visible: false, name: 'ModeloVeiculo', displayName: 'Modelo do Veículo', headerCellClass: 'ui-grid-header-text', cellClass: 'ui-grid-cell-contents', enableFiltering: true },
          
//    //       //{ field: 'ProdutoId', name: 'ProdutoId', visible: false }
//    //    ],
//    //    onRegisterApi: function (gridApi)
//    //    {
//    //        $scope.gridPesq = gridApi;

//    //        //$scope.gridPesq.treeBase.on.rowExpanded($scope, function (row)
//    //        //{
//    //        //    var rows = $scope.gridPesq.core.getVisibleRows($scope.gridPesq);              
//    //        //});

//    //        $scope.gridPesq.treeBase.on.rowExpanded($scope, function (row)
//    //        {
//    //            var index = 0;
//    //            var resultRequest = $scope.gridPesq.data;
//    //            var dado = $scope.gridPesq.data.filter(function (values) { return values.$$hashKey == row.entity.$$hashKey })[0]
//    //            for (var i = 0; i < resultRequest.length; i++) {
//    //                //if (dado.id == resultRequest[i].id) {
//    //                //    index = i;
//    //                //}
//    //                //if (row.entity.$$hashKey === dado.$$hashKey) {
//    //                //    //$scope.gridPesq.grid.renderContainers.body.visibleRowCache[0]
//    //                //    $scope.gridPesq.data.splice(dado, 0,
//    //                //    {

//    //                //        field: 'Arquivo',
//    //                //        name: 'Arquivo',
//    //                //        displayName: 'Arquivo',
//    //                //        headerCellClass: 'ui-grid-header-text',
//    //                //        cellClass: 'ui-grid-cell-contents',
//    //                //        enableFiltering: true,
//    //                //        Itens: values.Itens, $$treeLevel: 1
//    //                //    })
//    //                //}
//    //            }

//    //            //if (row.entity.$$hashKey === $scope.gridPesq.data[index].$$hashKey && !$scope.nodeLoaded)
//    //            //{                 
//    //            //    $scope.gridPesq.data[index].Itens[0].$$treeLevel = 1
//    //            //}


//    //            //var retorno = "";
                
//    //        });
//    //    }
//    //};


//    //$scope.STATUS = "ONLINE";
//    //$scope.MENSAGEM = "DEKRA T.I";
//    //$scope.GmudTipe = ["LIBERAÇÃO EMERGENCIAL", "LIBELRAÇÃO"];
//    //$scope.NUMEROGMUD = ["ATUAL 1461", "1459", "1458"];

//    //$scope.TOTAL_A = 6
//    //$scope.TOTAL_F = 4
        
//    //$scope.data =  {
//    //    model: null,
//    //    availableOptions: [{ id: '1461', name: '1461' },
//    //                       { id: '1460', name: '1460' },
//    //                       { id: '1459', name: '1459' }]
//    //};

//    //$scope.SOLICITANTE = ["EDNILSON MARTINS", "VAMDERLEI SILVA"];
//    //$scope.DEPARTAMENTOSOLICITANTE = ["PROJETOS", "ADMINISTRATIVO","VENDAS"];

//    //$scope.number = "A";
    
//    //$scope.Diretorios = function ()
//    //{
//    //    //{ params: params.Model }
//    //    //)

//    //    var model = {};
      
//    //    $http.get(path + "/home/Diretorios")
//    //                 .then(function (request)
//    //                 {
//    //                     var dados = request.data;

//    //                     //for (var i = 0; i < dados.length; i++)
//    //                     //{
//    //                     //    dados[i].$$treeLevel = 0
//    //                     //    var itenss = dados[i].Itens;

//    //                     //    for (var a = 0; a < itenss.length; a++)
//    //                     //    {
//    //                     //        dados[i].Itens[a].$$treeLevel = 0
//    //                     //    }
                            
//    //                     //}

//    //                     //angular.forEach(dados, function (value, index)
//    //                     //{                            
//    //                     //    value.$$treeLevel = 0;
//    //                     //    value.Itens.$$treeLevel = 1;                            
//    //                     //}); 
                        

//    //                     $scope.gridPesq.data = [];
//    //                     writeoutNode(dados, 0, $scope.gridPesq.data);

                         

//    //                 }).catch(function (request){
//    //                     console.log("Error" + request.message)
//    //                 }).finally(function (request){                       
//    //                     blockUI.stop("Pesquisa Finalizada")
//    //                 });
//    //};

//    //$scope.Diretorios();

//    //$scope.LoginForm = function () {

//    //    var Login = {
//    //        Username: $scope.Username,
//    //        Password: $scope.Password
//    //    }
//    //    var url = $location.url();
//    //    $scope.MENSAGEM = "BEM VINDO " + Login.Username;
//    //    $scope.cancel();
//    //    $window.location.href = url + "/Home/index";

//    //};
    
//    //$scope.getAggregates = function () {
//    //    var aggregatesTree = [];
//    //    var gender

//    //    var recursiveExtract = function (treeChildren) {
//    //        return treeChildren.map(function (node) {
//    //            var newNode = {};
//    //            angular.forEach(node.row.entity, function (attributeCol) {
//    //                if (typeof (attributeCol.groupVal) !== 'undefined') {
//    //                    newNode.groupVal = attributeCol.groupVal;
//    //                    newNode.aggVal = attributeCol.value;
//    //                }
//    //            });
//    //            newNode.otherAggregations = node.aggregations.map(function (aggregation) {
//    //                return { colName: aggregation.col.name, value: aggregation.value, type: aggregation.type };
//    //            });
//    //            if (node.children) {
//    //                newNode.children = recursiveExtract(node.children);
//    //            }
//    //            return newNode;
//    //        });
//    //    }

//    //    aggregatesTree = recursiveExtract($scope.gridApi.grid.treeBase.tree);

//    //    console.log(aggregatesTree);
//    //}

//}]);