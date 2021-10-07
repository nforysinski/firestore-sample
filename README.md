# firestore-sample

This app attempts to show an area where we have common issues in firestore. This app basically initializes a "batch" document in an activity tracking collection (which is temporary), as well as a document for long-term batch state. While one run of this is innocent, we often have tens->hundreds of this code being run at any given time for different sets of messaging going on.

Additionally, there are background services that occasionally come through and prune/clean documents created in this process. Those are not represented here, but are also writing/updating/deleting documents in these collections while the services that run those code are also doing the same.

![image](https://user-images.githubusercontent.com/1079113/136461286-cd079056-76f6-457a-a489-e8da16e0609b.png)

This is our example collection hierarchy within firestore so you can simulate that for yourself. The other collection (outgoing-activiy) is required to be created, but the sub documents self-create in the app.
