function SetSignedInUserProfile(userDisplayName, userEmail, profilePhotoUrl)
{
    $("#userDisplayName").text("Hello " + userDisplayName);
    $("#userEmail").text("Email " + userEmail)
    $("#profileImage").attr("src", profilePhotoUrl)
}

function ShowOrHideSignedInUserProfile(status)
{
    switch(status)
    {
        case HIDE_ELEMENTS:
            $("#signInUserProfile").hide()
            break;
        case SHOW_ELEMENTS:
            $("#signInUserProfile").show()
            break;
    }
}