
var app = angular.module('App', ['blockUI', 'ng-fusioncharts', 'ngTouch', 'ui.grid', 'ui.grid.exporter', 'ui.grid.cellNav', 'ivh.treeview', 'ui.grid.treeView', 'ui.grid.selection']);

var Obj;
var NovoGarantido;
var RobosAutomatizados;
var HistoricoDeRobos;
var path;
var vm;
var url;
var index1;
var ArraySelects = []


app.controller("CtrlVulnerabilidade", ['$rootScope', '$scope', '$http', '$location', '$window', 'blockUI', '$timeout', '$filter', '$interval', 'uiGridConstants', 
function ($rootScope, $scope, $http, $location, $window, blockUI, $timeout, $filter, $interval, $q, uiGridConstants) {
 
    //$scope.gridOptions.data.filter(function (value) {
    //    angular.forEach(value, function (value, index) {
    //        if(value.Identifica == "\\toyota\\Sites\dvlsmart.dekra.com.br\appChev")
    //        {
    //              return value;
    //        }
    //    })
      
    //})

    vm = this;
    Obj = $scope;
    path = window.location.origin;
    url = window.location.origin;

    $scope.cshtml = 0
    $scope.html = 0
    $scope.aspx = 0
    $scope.asp = 0
    $scope.htm = 0
    $scope.outros = 0

    $scope.DIRETORIO = "DIRETORIO RESULTADO";

    $scope.gridOptions = {
        enableSorting: true,
        enableFiltering: true,
        showTreeExpandNoChildren: true,
        enableRowSelection: true,
        enableRowHeaderSelection: true,
        enableSelectAll: true,
        multiSelect: true,
        noUnselect: false,
        modifierKeysToMultiSelect: true,
        columnDefs: [
          { name: 'name', width: '100%' },        
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.treeBase.on.rowExpanded($scope, function (row)
            {
                for (var i = 0; i < $scope.gridOptions.data.length; i++) {
                     var retorno = $scope.gridOptions.data.filter(function (v) { return v.$$hashKey === row.entity.$$hashKey })[0]
                     if (row.entity.$$hashKey === retorno.$$hashKey && !$scope.nodeLoaded)
                     {
                         $interval(function ()
                         {
                             $scope.gridOptions.data.splice(index1, 0,
                               { name: $scope.gridOptions.data[index1].name, $$treeLevel: 1 },
                               { name: $scope.gridOptions.data[index1].name, $$treeLevel: 1 }
                             );
                             $scope.nodeLoaded = true;
                         }, 2000, 1);
                         index1++;
                     }
                }
                //index1 = 0;
                //angular.forEach($scope.gridOptions.data, function (value, index)
                //{
                //    var retorno = $scope.gridOptions.data.filter(function (v) { return v.$$hashKey === row.entity.$$hashKey })[0]
                //    if (row.entity.$$hashKey === retorno.$$hashKey && !$scope.nodeLoaded)
                //    {                       
                //        $interval(function ()
                //        {
                //            $scope.gridOptions.data.splice(index1, 0,
                //              { name: 'Dynamic 1', gender: 'female', age: 53, company: 'Griddable grids', balance: 38000, $$treeLevel: 1 },
                //              { name: 'Dynamic 2', gender: 'male', age: 18, company: 'Griddable grids', balance: 29000, $$treeLevel: 1 }
                //            );
                //            $scope.nodeLoaded = true;
                //        }, 2000, 1);
                //    }
                //    index1 = index1 + 1;
                //})
                
                //$scope.gridOptions.data.splice(0, 1, { name: 'Dynamic 1', $$treeLevel: 1 });
                //$scope.gridOptions.data.forEach(function (val) {
                //    var a = val;
                //})
                //if (row.entity.$$hashKey ===  && !$scope.nodeLoaded) {
                //    $interval(function ()
                //    {
                //        $scope.gridOptions.data.splice(51, 0,
                //          { name: 'Dynamic 1', gender: 'female', age: 53, company: 'Griddable grids', balance: 38000, $$treeLevel: 1 },
                //          { name: 'Dynamic 2', gender: 'male', age: 18, company: 'Griddable grids', balance: 29000, $$treeLevel: 1 }
                //        );
                //        $scope.nodeLoaded = true;
                //    }, 2000, 1);
                //}
            });
            gridApi.selection.on.rowSelectionChanged($scope, function (row) {
              
                angular.forEach(row, function (value, index) {
                    ArraySelects.push(
                        {
                            "RetornoT":
                                {
                                 "ID": index,
                                 "LINHA": value.entity.Identifica
                                }
                        })
                    console.log(msg);
                });
                
            });
            gridApi.selection.on.rowSelectionChangedBatch($scope, function (rows) {
                
                angular.forEach(rows, function (value, index) {
                    //ArraySelects.push({ "ID": index, "LINHA": value.entity.Identifica })
                    ArraySelects.push(
                        { "ID": index,
                          "LINHA": value.entity.Identifica });                  
                });
            });
        }
    };

    
    //$scope.gridOptions = {
    //    enableSorting: true,
    //    enableFiltering: true,
    //    showTreeExpandNoChildren: true,
    //    enableRowSelection: true,
    //    enableRowHeaderSelection: true,
    //    enableSelectAll: true,
    //    multiSelect: true,
    //    noUnselect: false,
    //    modifierKeysToMultiSelect: true,
    //    columnDefs: [
    //      { name: 'name', width: '30%' },
    //      { name: 'gender', width: '20%' },
    //      { name: 'age', width: '20%' },
    //      { name: 'company', width: '25%' },
    //      { name: 'state', width: '35%' },
    //      { name: 'balance', width: '25%', cellFilter: 'currency' }
    //    ],
    //    onRegisterApi: function (gridApi) {
    //        $scope.gridApi = gridApi;
    //        $scope.gridApi.treeBase.on.rowExpanded($scope, function (row) {
    //            if (row.entity.$$hashKey === $scope.gridOptions.data[50].$$hashKey && !$scope.nodeLoaded)
    //            {
    //                $interval(function ()
    //                {
    //                    $scope.gridOptions.data.splice(51, 0,
    //                      { name: 'Dynamic 1', gender: 'female', age: 53, company: 'Griddable grids', balance: 38000, $$treeLevel: 1 },
    //                      { name: 'Dynamic 2', gender: 'male', age: 18, company: 'Griddable grids', balance: 29000, $$treeLevel: 1 }
    //                    );
    //                    $scope.nodeLoaded = true;
    //                }, 2000, 1);
    //            }
    //        });
    //        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
    //            var msg = 'row selected ' + row.isSelected;
    //            $log.log(msg);
    //        });
    //        gridApi.selection.on.rowSelectionChangedBatch($scope, function (rows) {
    //            var msg = 'rows changed ' + rows.length;
    //            $log.log(msg);
    //        });
    //    }
    //};

 //   $http.get('https://cdn.rawgit.com/angular-ui/ui-grid.info/gh-pages/data/500_complex.json')
 //   .then(function (response)
 //   {
 //            var data = response.data;

 //            for (var i = 0; i < data.length; i++) {
 //                data[i].state = data[i].address.state;
 //                data[i].balance = Number(data[i].balance.slice(1).replace(/,/, ''));
 //            }
 //            data[0].$$treeLevel = 0;
 //            data[1].$$treeLevel = 1;
 //            data[10].$$treeLevel = 1;
 //            data[11].$$treeLevel = 1;
 //            data[20].$$treeLevel = 0;
 //            data[25].$$treeLevel = 1;
 //            data[50].$$treeLevel = 0;
 //            data[51].$$treeLevel = 0;
 //            $scope.gridOptions.data = data;
 //});

  
    $scope.names = [];

    $scope.btnDiretorioSelect = function ()
    {
       var Url = "\\\\toyota\\\\Sites\\";     
       $http.get(path + "/Home/VulnerabilidadeDiretoriosList?Url=" + Url)
      .then(function (request) {
          var dados = request.data;
          $scope.names = dados;
      })
      .catch(function (response) {
          console.log(response);
      })
      .finally(function () {
          blockUI.stop();
        });


       

    }
    
    $scope.btnDiretorio = function () {
           
        var url = $scope.Vulnerabilidade.path;

        $http.get(path + "/Home/VulnerabilidadeDiretoriosParan?Url=" + url)
        .then(function (request)
        {
            var data = request.data;

            $scope.cshtml = 0
            $scope.html = 0
            $scope.aspx = 0
            $scope.asp = 0
            $scope.htm = 0
            $scope.outros = 0
           
            $scope.cshtml = data.filter(function (d) { return d.TipoArquivo == "cshtml" }).length
            $scope.html = data.filter(function (d) { return d.TipoArquivo == "html" }).length
            $scope.aspx = data.filter(function (d) { return d.TipoArquivo == "aspx" }).length
            $scope.asp = data.filter(function (d) { return d.TipoArquivo == "asp" }).length
            $scope.htm = data.filter(function (d) { return d.TipoArquivo == "htm" }).length
            $scope.outros = ($scope.cshtml + $scope.html + $scope.aspx + $scope.asp + $scope.htm)

            var nivel0 = []
            var nivel1 = []
            var JoinArray = []

            angular.forEach(data, function (value, index) {
                if (value.Nivel == 0) {
                    nivel0.push({ "name": value.name, "$$treeLevel": $$treeLevel = 0 })
                }
            });
            angular.forEach(data, function (value, index) {
                if (value.Nivel == 1) {
                    nivel1.push({ "name": value.name, "$$treeLevel": $$treeLevel = 1 })
                }
            });

            JoinArray = nivel0.concat({ "name": nivel1 })

            //name = item,
            //       Nivel = 0,
            //       Identifica = item,
            for (var i = 0; i < data.length; i++) {
                if (data[i].Nivel == 0) {
                    data[i].$$treeLevel = 0;
                    data[i].name = data[i].name;
                } else {
                    data[i].$$treeLevel = 1;
                    data[i].name = data[i].name;
                }
            }

          

            $scope.gridOptions.data = data;
            $scope.names = dados;
        })
        .catch(function (response) {
            console.log(response);
        })
        .finally(function () {
            blockUI.stop();
        });
             
    };

    $scope.btnTesteParametrizado = function () {

        var url = $scope.Vulnerabilidade.path;
        //var params = {};
        //params.Model =
        var Model = JSON.stringify(ArraySelects);
        //var Model = ArraySelects;

        $http.post(path + "/Home/TesteDeVulnerabilidadeII",
         { Model: Model })
        .then(function (request) {
                    
            var returns = request.data;
            $scope.DIRETORIO = returns;
            //var nivel0 = []
            //var nivel1 = []
            //var JoinArray = []

            //angular.forEach(data, function (value, index) {
            //    if (value.Nivel == 0) {
            //        nivel0.push({ "name": value.name, "$$treeLevel": $$treeLevel = 0 })
            //    }
            //});
            //angular.forEach(data, function (value, index) {
            //    if (value.Nivel == 1) {
            //        nivel1.push({ "name": value.name, "$$treeLevel": $$treeLevel = 1 })
            //    }
            //});

            //JoinArray = nivel0.concat({ "name": nivel1 })

            ////name = item,
            ////       Nivel = 0,
            ////       Identifica = item,
            //for (var i = 0; i < data.length; i++) {
            //    if (data[i].Nivel == 0) {
            //        data[i].$$treeLevel = 0;
            //        data[i].name = data[i].name;
            //    } else {
            //        data[i].$$treeLevel = 1;
            //        data[i].name = data[i].name;
            //    }
            //}



            //$scope.gridOptions.data = data;
            //$scope.names = dados;
        })
        .catch(function (response) {
            console.log(response);
        })
        .finally(function () {
            blockUI.stop();
        });

    };

    $scope.btnDiretorioSelect();
  

}]);

