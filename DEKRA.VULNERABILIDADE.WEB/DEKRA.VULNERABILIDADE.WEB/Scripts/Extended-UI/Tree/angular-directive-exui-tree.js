/// <reference path="~/Scripts/angular.js" />
/// <reference path="~/Scripts/jquery-1.12.0.js" />

/**
 * README
 * =========================================================
 * 定义了angular.js树指令。
 * 作者：王 玉才
 * 日期：2016年4月9日
 * 版本：1.0.0
 * 授权：Apache License 2.0
 * JavaScript库依赖：
 *      1) Angular.js 1.5.3
 *      2) jQuery.js 1.12.0
 */

/**
 * 定义了默认的树节点架构,请参照以下结构定义树节点数据源。
 */
//var defaultTreeNodeOptions = {
//isLeaf: false, //是否为叶子节点。
//isExtended: false, //是否已经展开。
//hasExtended: false, //是否已经展开过一次。
//text: "这是一个测试节点", //树节点显示文本。
//value: "00000000-0000-0000-0000-000000000000", //树节点值。
//tag: undefined, //树节点扩展属性值。
//showIcon: false, //是否显示树节点私有图标。
//iconUri: undefined, //树节点私有图标URL。
//showCheckBox: false, //是否显示复选框。
//isChecked: false, //是否处于被选中状态。
//isSelected: false, //是否处于被选中状态。
//childNodes: [], //树节点的子节点。
//inLoading: false //是否正处于加载状态。
//};

/**
 * 注册树形指令。
 */
(
    function (ng) {

        /**
         * AngularJS Extended-UI树形指令接口函数。
         * @returns {DirectiveInterfaceSchema} 
         * @author 王 玉才
         */
        function interfaceOfExtendedTree() {
            return {
                restrice: "EA",
                replace: true,
                transclude: true,
                template: "<div ng-transclude></div>",
                controller: function ($scope, $element, $attrs) {
                    this.__ExtendedTreeUISettings = {
                        lazyloadingImageUri: $attrs.lazyLoadingImage,
                        setSelectedNode: function (node) {
                            if ($scope.selectedNode)
                                $scope.selectedNode.isSelected = false;
                            $scope.selectedNode = node;
                        },
                        raiseNodeExtendedEvent: function (sender, e) {
                            if ($scope.onNodeExtended) {
                                $scope.onNodeExtended(sender, e);
                            }
                        }
                    };
                },
                controllerAs: "exuiTreeController",
                scope: {
                    selectedNode: "=",
                    checkedNodes: "=",
                    onNodeExtended: "="
                }
            };
        }

        /**
         * AngularJS Extended-UI树形节点指令接口函数。
         * @returns {} 
         */
        function interfaceOfExtendedTreeNode() {
            return {
                restrice: "E",
                replace: true,
                transclude: false,
                templateUrl: "/Content/Extended-UI/Tree/ExtendedUI-Tree-NodeTemplate.html",
                scope: {
                    nodeData: "="
                },
                require: "^exuiTree",
                link: function (scope, element, attrs, exuiTreeController) {
                    //var node = angular.extend({}, defaultTreeNodeOptions, scope.nodeData);
                    //scope.nodeData = node;
                    console.log(scope.nodeData);
                    scope.__loadingImageUri = exuiTreeController.__ExtendedTreeUISettings.lazyloadingImageUri;

                    scope.events = {
                        onSelected: function () {
                            scope.nodeData.isSelected = true;
                            exuiTreeController.__ExtendedTreeUISettings.setSelectedNode(scope.nodeData);
                        },
                        onIconClick: function () {
                            if (!scope.nodeData.hasExtended) {
                                scope.nodeData.hasExtended = true;
                                scope.nodeData.inLoading = true;
                                (
                                    function (sender, e) {
                                        exuiTreeController.__ExtendedTreeUISettings.raiseNodeExtendedEvent(sender, e);
                                        scope.nodeData.inLoading = false;
                                    }
                                )(scope.nodeData, { currentNode: scope.nodeData, hasExtended: true });
                            }

                            scope.nodeData.isExtended = !scope.nodeData.isExtended;
                        }
                    };
                }
            };
        }

        ng.module("angularExtendedUI.tree", [])
            .directive(
                "exuiTree",
                interfaceOfExtendedTree
            )
            .directive(
                "exuiTreeNode",
                interfaceOfExtendedTreeNode
            );

    }
)(angular);