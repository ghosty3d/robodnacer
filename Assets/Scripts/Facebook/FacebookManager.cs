﻿/**
 * Facebook Manager class uses for oparate Facebook functional.
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;


public class FacebookManager {

	List<string> perms = new List<string>(){"public_profile", "email", "user_friends", "publish_actions"};

	public void Init() {
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK

			if(!FB.IsLoggedIn) {
				FB.LogInWithPublishPermissions(perms, AuthCallback);	
			}

		} else {
			Debug.LogError("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}


	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}

		} else {
			Debug.Log("User cancelled login");
		}
	}

	public void ShareWithFacebook() {
		FB.ShareLink(
			new Uri("https://www.facebook.com/games/?app_id=132712127243538"),
			callback: ShareCallback
		);
	}

	private void ShareCallback (IShareResult result) {
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
		} else if (!String.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
		} else {
			// Share succeeded without postID
			Debug.Log("ShareLink success!");
		}
	}

	public void InviteFriends() {
		FB.Mobile.AppInvite(
			new Uri("https://www.facebook.com/games/?app_id=132712127243538"),
			new Uri("http://i.imgur.com/zkYlB.jpg"),
			AppInviteCallback
		);
	}

	private void AppInviteCallback(IAppInviteResult result) {
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("AppInvite Error: "+result.Error);
		} else {
			Debug.Log("AppInvite success!");
		}
	}
}
