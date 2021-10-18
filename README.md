# TestAvidity

In order to run the solution you first need to add the clientId and clientSecret for the OAuth2 token
 
 

In order to create a clientId and a clientSecret
Step 1: First of all you need to visit the GitHub Developer website https://github.com/settings/developers to get these details.
Step 2: It will ask you to login to your GitHub account first. After logging in click on the Developer settings tab.
Step 3: Create a New OAuth application
Step 4: Add all the details. For the Authorization callback URL you need to add: https://localhost:44358/github-oauth
Step 5: Hit the “Register application” button after filling all the required details.
Step 6: The next interface will show the Client ID and Client Secret details. 
Step 7: Copy the 2 infos and add them in  the appsettings.json
 "GitHub": {
    "ClientId": "",
    "ClientSecret": ""
	
Now, on the first run you will need see a button to login to Github. After the loggin you will see the cards with the contributors page for the chosen repository.  
The repository is read from  appsettings.json. The default is  https://api.github.com/repos/avidity/racconto
