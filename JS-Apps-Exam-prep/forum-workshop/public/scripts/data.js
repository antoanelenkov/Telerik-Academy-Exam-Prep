var data = (function () {
    //---------------POSTS--------------------
    function getAllPosts() {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/threads',
                type: 'get',
                contentType: 'application/json',
                success: function (data) {
                    resolve(data);
                },
                error: function(err){
                    console.log('error while loading all posts: '+err)
                }
            });
        })

        return promise;
    }

    function getPostById() {

    }

    function addPost() {

    }

    function addMessageToPostWithId() {

    }


    //---------------USERS--------------------
    function registerUser() {

    }

    function loginUser() {

    }

    function getCurrentUser(){
        return null;
    }

    function getAllUsers() {

    }

    return {
        posts: {
            getAll: getAllPosts,
            getById: getPostById,
            addPost: addPost,
            addMessageToPostWithId: addMessageToPostWithId
        },
        users: {
            register: registerUser,
            login: loginUser,
            getAll: getAllUsers,
            getCurrent:getCurrentUser
        }
    }
}());
