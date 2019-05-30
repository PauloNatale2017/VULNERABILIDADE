var app = angular.module('app', ['ui.grid', 'ui.grid.treeView']);

app.controller('MainCtrl', ['$scope', '$http', function ($scope, $http) {

    var vm = this
    Obj = $scope;
    path = window.location.origin;

    $scope.Diretorios = function () {
        //{ params: params.Model }
        //)

        var model = {};
        var array = []
        var dado = {}
        var NewModel = 
         {
             "GMUD": null,
             "DESCRIÇÃO": null,
             "ubi_pad_id": null,
             "ubi_tip_id": null,
             "$$treeLevel": null
         }


        $http.get(path + "/home/Diretorios")
                     .then(function (request)
                     {
                         var dados = request.data;
                         
                         var count = 0;
                         angular.forEach(dados, function (value, index)
                         {
                          
                             array.push({ "GMUD": value.id, "DESCRIÇÃO": value.Descricao, "ubi_pad_id": value.id, "ubi_tip_id": 1, "$$treeLevel": 0 })
                             for (var i = 0; i < value.Itens.length; i++)
                             {
                                 var mod = {
                                     id: value.id,
                                     Descricao: value.Itens[i].Descricao
                                 }  
                                 array.push({ "GMUD": value.id, "DESCRIÇÃO": mod.Descricao, "ubi_pad_id": value.id, "ubi_tip_id": 2, "$$treeLevel": 1 })
                                
                             }                             
                         
                         });
                      
                         $scope.myData = array

                     }).catch(function (request) {
                         console.log("Error" + request.message)
                     }).finally(function (request) {
                         blockUI.stop("Pesquisa Finalizada")
                     });
    };

    $scope.Diretorios();

    var rowtpl = '';
    rowtpl += '<div class=\"{{grid.appScope.rowLevel(row)}}\">';
    rowtpl += '<div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name"';
    rowtpl += 'class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader }" ui-grid-cell>';
    rowtpl += '</div>';
    rowtpl += '</div>';
       

    $scope.gridOptions2 = {
        data: 'myData',
        columnDefs:
        [
             {
                 field: 'GMUD',
                 name: 'GMUD',
                 width: '300',
                 heigth: '100',
                 displayName: 'GMUD',
                 headerCellClass: 'ui-grid-header-text',
                 cellClass: 'ui-grid-cell-contents',
                 enableFiltering: true,
             },
              {
                  field: 'DESCRIÇÃO',
                  name: 'DESCRIÇÃO',
                  width: '1150',
                  heigth: '100',
                  displayName: 'DESCRIÇÃO',
                  headerCellClass: 'ui-grid-header-text',
                  cellClass: 'ui-grid-cell-contents',
                  enableFiltering: true,
                  cellTemplate: '<div style="float:left;background-color:transparent;height: 39px !important;width: 100% !important;">{{COL_FIELD}}' +
                                  '<div style="float:right; background: url(/images/Icons/Delete/9.png); background-repeat: no-repeat; border-radius: 18px;background-size:  100% 100%;height: 32px !important;width: 32px !important;display: inline-flex;cursor:pointer; float: right; margin-right: 11px;">' +
                                  '</div>' +
                                  '<div style="float:right; background: url(/images/Icons/Add/4.png); background-repeat: no-repeat; border-radius: 18px;background-size:  100% 100%;height: 32px !important;width: 32px !important;display: inline-flex;cursor:pointer; float: right; margin-right: 11px;">' +
                                  '</div>' +
                                  '<div style="float:right; background: url(/images/Icons/Edit/2.png); background-repeat: no-repeat; border-radius: 18px;background-size:  100% 100%;height: 32px !important;width: 32px !important;display: inline-flex;cursor:pointer; float: right; margin-right: 11px;">' +
                                  '</div>' +
                               
                                +'</div>'
              },
        ],
        rowTemplate: rowtpl,
    };
    

    $scope.rowLevel = function (row)
    {
        var cls = '';
        if (row.treeLevel != void 0) {
            cls = 'rowLevel-' + row.treeLevel;
        }
        return cls;
    }
}]);


