(function (app) {
    app.controller('postAddController', postAddController);

    postAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'authData'];

    function postAddController(apiService, $scope, notificationService, $state, authData) {
        var userName = authData.authenticationData.userName;


        $scope.AddPost = AddPost;

        $scope.post = {
            CreatedBy: userName,
            Status: true,
        };

        var historyAction = {
            "ActionName": "Thêm mới bài viết",
            "Status": 1,
            "UserName": authData.authenticationData.userName,
        };


        $scope.ckeditorOptions = {
            language: "vi",
            height:'300px',
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            }
            finder.popup();
        }

        function AddPost() {
            console.log($scope.post);
            apiService.post('api/post/create', $scope.post,
                function (result) {
                    notificationService.displaySuccess('Thêm mới thành công.');
                    $state.go('posts');
                }, function (error) {
                    historyAction["Status"] = 0;
                    notificationService.displayError('Thêm mới không thành công.');
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
    }
})(angular.module('management.posts'));