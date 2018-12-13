(function (app) {
    app.controller('postListController', postListController);

    postListController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$ngBootbox', 'authData'];

    function postListController(apiService, $scope, notificationService, $state, $ngBootbox, authData) {
        var userName = authData.authenticationData.userName;
        $scope.posts = [];
        $scope.keyword = '';

        $scope.getposts = getposts;
        $scope.deletePost = deletePost;
        $scope.search = search;

        var historyAction = {
            "ActionName": "Xoá bài viết",
            "Status": 1,
            "UserName": userName,
        };

        function deletePost(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/post/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    historyAction["Status"] = 0;
                    notificationService.displayError('Xóa không thành công');
                })
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

        function search() {
            getposts();
        }

        function getposts() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/post/getall', config, function (result) {
                console.log(result);
                if (result.data.length === 0 ) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.posts = result.data;
            }, function () {
                console.log('Load Post failed.');
            });
        }
        $scope.getposts();
    }
})(angular.module('management.posts'));