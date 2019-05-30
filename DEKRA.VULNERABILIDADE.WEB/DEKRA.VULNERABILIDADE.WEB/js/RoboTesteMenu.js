
var app = angular.module('App', ['blockUI', 'ng-fusioncharts', 'ngTouch', 'ui.grid', 'ui.grid.exporter', 'ui.grid.selection','ui.grid.cellNav']);

var Obj;
var NovoGarantido;
var RobosAutomatizados;
var HistoricoDeRobos;
var path;
var vm;
var url;
var Chart1;
var dados = [];
var total = 10

var Data = []
var Line = []
var Config = []
var chartSource = {}
var Charts 


app.controller("CtrlLayout2", ['$rootScope','$scope', '$http','$location', '$window', 'blockUI', '$timeout', '$filter', '$interval', 'uiGridConstants',
function ($rootScope, $scope, $http,  $location, $window, blockUI, $timeout, $filter, $interval, $q, uiGridConstants) {
        
    //var timer = $interval(function ()
    //{       
    //    FusionCharts.ready(function () {         
    //        $scope.Charts.render();
    //    });
      
    //}, 4000);

    $scope.hideGrid = true;

    vm = this;
    Obj = $scope;

    path = window.location.origin;
    url = window.location.origin;
    
    vm.gridSistemas = {};
    vm.gridBases = {};
    vm.gridFuncoes = {};
   
    var ConfigcolumnDefs = [
                            { name: 'Id', field: 'Id', height: "50", visible: false },
                            //{ name: 'edit', field: '', height: "50", width: "40", displayName: '', enableFiltering: false, cellTemplate: "<button  class='w3-btn w3-ripple' ng-click='editUser(user.id)'>&#9998; Edit</button>" },
                            { name: 'Sigla', field: 'Sigla', height: "50", },
                            { name: 'NomeSistema', field: 'NomeSistema', height: "50", },
                            { name: 'Ambiente', field: 'Ambiente', height: "50", },
                            //{ name: 'edit', field: '', height: "50", width: "40", displayName: '', enableFiltering: false, cellTemplate: "<input type='checkbox' ng-true-value=''YES'' ng-false-value=''NO''>" }
                           ]
    var ConfigcolumnDefs1 = [
                              { name: 'Id', field: 'Id', height: "50", visible: false },
                               //{ name: 'edit', field: '', height: "50", width: "40", displayName: '', enableFiltering: false, cellTemplate: "<input type='checkbox' ng-true-value=''YES'' ng-false-value=''NO''>" },
                              { name: 'Servidor', field: 'Servidor', height: "50", },
                              { name: 'DataBase', field: 'DataBase', height: "50", },
                              { name: 'Funcoes', field: 'Funcoes', height: "50", },
                              { name: 'Jobs', field: 'Jobs', height: "50", },
                              { name: 'Triggers', field: 'Triggers', height: "50", },
                              { name: 'DataCreate', field: 'DataCreate', height: "50", },
                              { name: 'DataUpdate', field: 'DataUpdate', height: "50", }
                            ]
    var ConfigcolumnDefs2 = [
                              { name: 'Id', field: 'Id', height: "50", visible: false },
                              //{ name: 'edit', field: '', height: "50", width: "40", displayName: '', enableFiltering: false, cellTemplate: "<input type='checkbox' ng-true-value=''YES'' ng-false-value=''NO''>" },
                              //{ name: 'edit', field: '', height: "50", width: "40", displayName: '', enableFiltering: false, cellTemplate: "<button  class='w3-btn w3-ripple' ng-click='editUser(user.id)'>&#9998; Edit</button>" },
                              { name: 'TipoTeste', field: 'TipoTeste', height: "50", },
                              { name: 'DescricaoTeste', field: 'DescricaoTeste', height: "50", },
                              { name: 'Usuario', field: 'Usuario', height: "50", },
                              { name: 'SenhaUsuario', field: 'SenhaUsuario', height: "50", },
                              { name: 'ScriptsBanco', field: 'ScriptsBanco', height: "50", },
                              { name: 'ScriptSistema', field: 'ScriptSistema', height: "50", },
                              { name: 'DataCreate', field: 'DataCreate', height: "50", },
                              { name: 'DataUpdate', field: 'DataUpdate', height: "50", },
                            ]
   
    vm.gridSistemas = {
        //enableSorting: true,
        //enableFiltering: true,
        //rowHeight: 38,
        //useExternalPagination: false,
        //useExternalSorting: false,     
        //enableColumnMenus: false,      
        //enableRowHeaderSelection: false,
        //enableRowSelection: true,
        //enableSelectAll: true,
        //enableGridMenu: false,
        //exporterMenuPdf: false,
        //showGridFooter:true,
        enableRowSelection: true,
        enableSelectAll: true,
        selectionRowHeaderWidth: 35,
        rowHeight: 35,
        showGridFooter:true,
        columnDefs: ConfigcolumnDefs,
        data: '$ctrl.Sistemas'
    };

 
   
    vm.gridBases = {
        enableSorting: true,
        enableFiltering: true,
        rowHeight: 38,
        useExternalPagination: false,
        useExternalSorting: false,
        enableColumnMenus: false,
        enableRowSelection: true,
        enableGridMenu: false,
        exporterMenuPdf: false,
        columnDefs: ConfigcolumnDefs1,
        data: '$ctrl.Bases'
    };
    vm.gridFuncoes = {
        enableSorting: true,
        enableFiltering: true,
        rowHeight: 38,
        useExternalPagination: false,
        useExternalSorting: false,
        enableColumnMenus: false,
        enableRowSelection: true,
        enableGridMenu: false,
        exporterMenuPdf: false,
        columnDefs: ConfigcolumnDefs2,
        data: '$ctrl.Funcoes'
    };
   
                
    $scope.GreficoNovoGarantido = function () {

        $http.get(path + "/api/Charts/")
        .then(function (request) {

            var dados = request.data;

            Data = [];
            var countVoltas = 0
            var mediaTotal = 0

            var media = [
                { "val": 2.358 },
                { "val": 4.358 },
                { "val": 5.358 },
                { "val": 6.358 },
                { "val": 7.358 },
                { "val": 0.358 },
                { "val": 1.358 },
                { "val": 9.358 }]

            var medias = (media) / 8;

            Line = [{
                "startvalue": 10,
                "color": "#29C3BE",
                "displayvalue": "Tempo Medio (" + 5.365 + ")",
                "valueOnRight": "1",
                "thickness": "3"
            }]

            Config = {
                "caption": "TEMPO MEDIO DO PROCESSO DE TESTE",
                "xAxisName": "NOVO GARANTIDO",
                "yAxisName": "FLUXO",
                "numberPrefix": "",
                "theme": "fusion",
                "showLabels": "1"
            }

            chartSource = {
                "chart": Config,
                "data": Data,
                "trendlines": [{ "line": Line }]               
            }

            var aData = []


            angular.forEach(dados, function (values, index) {
                aData.push({
                    "link": "www.google.com.br", "anchorBgHoverColor": "#ff0000",
                    "valuePosition": "ABOVE", "label": values.label.toString(), "value": values.value.toString(), "color": "#AFD249", "labelFontColor": "#008955", "showLabel": "1", "showValue ": "1", "color": "#ff0000"
                })
            });

            FusionCharts.ready(function ()
            {
                var Charts = new FusionCharts(
                {  
                    "width": "850",
                    "height": "200",
                    "type": "line",
                    "renderAt": "chart-container",
                    "dataformat": "json",
                    "dataSource":
                     {
                         "chart": {                          
                             "caption": "TEMPO MEDIO DO PROCESSO DE TESTE",
                             "xAxisName": "NOVO GARANTIDO",
                             "yAxisName": "FLUXO",
                             "numberPrefix": "",
                             "theme": "fusion",
                             "showLabels": "1"
                         },
                         "data": aData,
                         "trendlines": [{ "line": Line }]
                     }

                });
                Charts.render();
            });

            blockUI.stop();


        })
        .catch(function (response) {
            console.error('DadosCheckGraficos error', response.status, response.data);
        })
        .finally(function () {
            blockUI.stop();
        });
             
    };
    
    $scope.InicializaTeste = function () {

        //var model = {
        //    Banco: "dbSmart",
        //    Funcao: "Create",
        //    Url:"http://hml.checkauto.com.br/Recall/Admin/Login"
        //};

        ////var data = JSON.stringify(model);

        blockUI.start("GERANDO DADOS ESTATISTICOS DO PROCESSO");

       // $scope.GreficoNovoGarantido();

        //var  Urls = "http://hml.checkauto.com.br/Recall/Admin/Login"


        //$http.get(path + "/Home/Testes?data=" +Urls)
        //.then(function (request) {
        //    var dados = request.data;
        //    $scope.GreficoNovoGarantido();
        //})
        //.catch(function (response) {
        //    console.error('DadosCheckGraficos error', response.status, response.data);
        //})
        //.finally(function () {
        //    blockUI.stop();
        //});

        $scope.GreficoNovoGarantido();
    };
    
    $scope.SistemasModel = function () {

         blockUI.start("BUSCANDO SISTEMAS CADASTRADOS DEKRA")
        //var Urls = "http://hml.checkauto.com.br/Recall/Admin/Login"
          
        $http.get(path + "/api/Sistemas/")
        .then(function (request) {
            var retorno = request.data;
            vm.Sistemas = retorno;
        })
        .catch(function (response) {
            console.error('DadosCheckGraficos error', response.status, response.data);
        })
        .finally(function () {
            $timeout(function () {
                blockUI.stop();
            }, 4000)
          
        });

    };

    $scope.SistemasModel1 = function () {

        blockUI.start("BUSCANDO SERVIDORES DE BASE DE DADOS")
        //var Urls = "http://hml.checkauto.com.br/Recall/Admin/Login"

        $http.get(path + "/api/Bases/")
        .then(function (request) {
            var retorno = request.data;
            vm.Bases = retorno;

        })
        .catch(function (response) {
            console.error('DadosCheckGraficos error', response.status, response.data);
        })
        .finally(function () {
            $timeout(function () {
                blockUI.stop();
            }, 4000)
        });

    };

    $scope.SistemasModel2 = function () {

        blockUI.start("BUSCANDO LISTA DE TESTES AUTOMATIADOS")
        //var Urls = "http://hml.checkauto.com.br/Recall/Admin/Login"

        $http.get(path + "/api/Funcoes/")
        .then(function (request) {
            var retorno = request.data;
            vm.Funcoes = retorno;
        })
        .catch(function (response) {
            console.error('DadosCheckGraficos error', response.status, response.data);
        })
        .finally(function () {
            $timeout(function () {
                blockUI.stop();
            }, 4000)
        });

    };

    $scope.LoginForm = function () {

      

        $scope.GreficoNovoGarantido();

        //$window.location.href = url + "/Home/LogIn2";
        //blockUI.start("EXECUTANDO TESTE AUTOMATIZADO")
        //$timeout(function () {
        //    blockUI.stop();
        //});
    };
    
    //$scope.GreficoNovoGarantido();

}]);

