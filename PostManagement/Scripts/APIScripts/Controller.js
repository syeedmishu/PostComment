app.controller('APIController', function ($scope, APIService) {

    $scope.searchKeyword = "";
    getPosts();
    function getPosts() {
        var servCall = APIService.getPosts();
        servCall.then(function (d) {
            $scope.Posts = d;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.')
        });
    }
    $scope.getSearchData = function (data) {
        if (data == null || data == "") {
            getPosts();
        } else {
            var servCall = APIService.getPostsByKeyward(data);
            servCall.then(function (d) {
                $scope.Posts = d;
            }, function (error) {
                console.log('Oops! Something went wrong while fetching the data.')
            });
        }
       
      
    };
});