function BtnOnClickGoogleSignIn(callback) {
    $("#googleSignIn").on('click', function (event) {
        authManager.SignIn(function () {
            authManager.GenerateToken(function (token) {
                userManager.GetCurrentUserBasicInfo(function (userDisplayName, userEmail, userUid) {
                    userManager.AppendUserInfo(userDisplayName, userEmail, userUid, token, function (resultMsg) {
                        if (callback !== undefined) {
                            callback()
                        }
                    })
                })
            })
        })        
    })
}