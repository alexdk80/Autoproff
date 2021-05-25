<template>
  <div class="carauction">
	<h1>{{ title }}</h1>
	<h2>You are at a right place to get a car </h2>
  </div>
</template>

<script>
export default {
  data () {
	  return {
  	  title: 'Car Auction Application'
	  }
  }
}
</script>

<style>
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #35495E;
}
</style>