(function (app) {
    app.controller('postEditController', postEditController);

    postEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService', 'authData'];

    function postEditController(apiService, $scope, notificationService, $state, $stateParams, commonService, authData) {
        var userName = authData.authenticationData.userName;


        $scope.UpdatePost = UpdatePost;

        var historyAction = {
            "ActionName": "Cập nhật bài viết",
            "Status": 1,
            "UserName": userName,
        };

        function loadpostDetail() {
            apiService.get('api/post/getbyid/' + $stateParams.id, null, function (result) {
                $scope.post = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdatePost() {
            $scope.post["UpdatedBy"] = userName;
            apiService.put('api/post/update', $scope.post,
                function (result) {
                    notificationService.displaySuccess('Cập nhật lộ trình thành công.');
                    $state.go('posts');
                }, function (error) {
                    historyAction["Status"] = 0;
                    notificationService.displayError('Cập nhật không thành công.');
                });
            apiService.post('api/historyaction/create', JSON.stringify(historyAction),
                function () {
                    console.log("Lưu lịch sử thành công");
                },
                function () {
                    console.log("Không lưu lịch sử thành công");
                }
            )
        }
        loadpostDetail();
    }
})(angular.module('management.routes'));