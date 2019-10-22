

##### Simple Query
```
{
  owners {
    id,
    name,
    address,
    accounts {
    	id,
      description,
      ownerId
    }
  }
}
```
##### Query with ID
```
{
  owner(ownerId:"b75b9284-95df-4ad7-b5fa-accff0effff3") {
    id,
    name,
    address,
    accounts {
    	id,
      description
    }
  }
}
```
##### Aliases
```
{
  first: owner(ownerId:"b75b9284-95df-4ad7-b5fa-accff0effff3") {
    id,
    name,
    address,
    accounts {
    	id,
      type
    }
  },
  second: owner(ownerId:"fab26154-d97e-4657-83ab-a0769340b978") {
    id,
    name,
    address,
    accounts {
    	id,
      type
    }
  },
}
```
##### Fragments allow us to separate common fields
```
{
  first: owner(ownerId:"b75b9284-95df-4ad7-b5fa-accff0effff3") {
    ...ownerFields
  }
  second: owner(ownerId:"fab26154-d97e-4657-83ab-a0769340b978") {
    ...ownerFields
	}
},

fragment ownerFields on OwnerType {
    id,
    name,
    address,
    accounts {
    	id,
      type
    }
}
```
##### Named query and query variables
```
query ownerQuery($ownerID: ID!){
    owner(ownerId: $ownerID){
        id,
        name,
        address,
        accounts{
            id,
            type
        }
    }
}

// in the query variables
{
  "ownerID": "b75b9284-95df-4ad7-b5fa-accff0effff3"
}
```

##### Directives (include, skip) in queries
```
query ownerQuery($ownerID: ID!, $showName: Boolean!){
    owner(ownerId: $ownerID){
        id,
        name @skip(if: $showName),
        address,
        accounts{
            id,
            type
        }
    }
}

// in the query variables
{
  "ownerID": "b75b9284-95df-4ad7-b5fa-accff0effff3",
  "showName": true
}
```

##### mutation create request
```
 mutation($owner: ownerInput!) {
        createOwner(owner: $owner) {
            id,
            name,
            address
        }
 }
// in the query variables
{
  "owner": {
    "name": "new name",
    "address": "new address"
    }
}
```
##### mutation delete request
```
mutation($ownerId: ID!) {
    deleteOwner(ownerId: $ownerId)
}
// in the query variables
{
    "ownerId":"21432e2ed32d23"
}
```
##### mutation update request
```
mutation($owner: ownerInput!, $ownerId: ID!){
  updateOwner(owner: $owner, ownerId: $ownerId){
        id,
        name,
        address
    }
}
// in the query variables
{
    "owner": {
        "name": "edited name",
        "address": "edited address"
        },
    "ownerId":"124ew9h2308h328"
}
```