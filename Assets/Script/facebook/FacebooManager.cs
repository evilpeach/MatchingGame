using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FacebooManager : MonoBehaviour {

    public Text userIdText;
    private void Awake()
    {
        if (!FB.IsInitialized)
            FB.Init();
        else
        {
            FB.ActivateApp();
            Debug.Log("You're successful init facebook.");
        }
    }

    public void LogIn()
    {
        FB.LogInWithReadPermissions(callback:OnLogIn);
    }

    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            AccessToken token = AccessToken.CurrentAccessToken;
            userIdText.text = token.UserId;
        }
        else
            Debug.Log("Canceled Login");
    }

    public void Share()
    {
        /*FB.ShareLink(
            contentTitle: "GLED MUMU",
            contentURL: new System.Uri("http://google.com"),
            contentDescription: "Kabigon huhuhu",
            photoURL: new System.Uri("https://scontent.fbkk1-1.fna.fbcdn.net/v/t1.0-9/17883548_1429957310400358_7139435178302893155_n.jpg?oh=6fbfdea32a9cc98ffe460ba9eb2182c6&oe=5986626E"),
            callback: OnShare);*/

        FB.FeedShare(
            link: new System.Uri("https://scontent.fbkk1-1.fna.fbcdn.net/v/t1.0-9/17883548_1429957310400358_7139435178302893155_n.jpg?oh=6fbfdea32a9cc98ffe460ba9eb2182c6&oe=5986626E"),
            linkName: "The mumu",
            linkCaption: "I thought up a witty tagline about larches #tag #test",
            linkDescription: "There are a lot of larch trees around here, aren't there?",
            picture: new System.Uri("https://scontent.fbkk1-1.fna.fbcdn.net/v/t1.0-9/17883548_1429957310400358_7139435178302893155_n.jpg?oh=6fbfdea32a9cc98ffe460ba9eb2182c6&oe=5986626E"),
            callback: OnShare);

    }

    private void OnShare(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Share Link error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
            Debug.Log("Share success");
    }
}
