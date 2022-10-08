const serviceWorker = {
    Actions: {
        Post: function (parameters) {
            var result;
            $.ajax({
                method: "POST",
                url: parameters.url,
                data: parameters.data,
                async: false,
                success: function (response) {
                    result = response;
                },
                catch: function (err) {
                    console.log(err);
                }
            })
            return result;
        },
    },
};
