<template>
  <v-container
    style="margin:1rem; display:flex; flex-direction: row; justify-content: space-evenly;"
  >
    <ApolloQuery :query="require('../graphql/queries/allOwners.gql')">
      <template v-slot="{result: {loading, error, data}}">
        <div>
          <h3 v-if="loading">Loading..</h3>
          <h3 v-if="error">Please try again allOwners.</h3>
          <div v-if="data">
            <span class="title">Without Variables</span>
            <h4 v-for="owner in data.owners" :key="owner.id">{{owner.name}}</h4>
          </div>
        </div>
      </template>
    </ApolloQuery>
    <ApolloQuery :query="require('../graphql/queries/ownerById.gql')" :variables="{ownerID}">
      <template v-slot="{result: {loading, error, data}}">
        <div>
          <h3 v-if="loading">Loading..</h3>
          <h3 v-if="error">Please try again ownerById.</h3>
          <div v-if="data">
            <span class="title">With Variables</span>
            <h4>{{data.owner.address}}</h4>
          </div>
        </div>
      </template>
    </ApolloQuery>
  </v-container>
</template>

<script>
import { Component } from "vue";
import gel from "graphql-tag";

export default {
  name: "FetchData",
  data() {
    return {
      ownerID: "b75b9284-95df-4ad7-b5fa-accff0effff3"
    };
  }
};
</script>

<style>
.title {
  color: darkslateblue;
  font-size: 2rem;
}
</style>