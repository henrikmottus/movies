<script>
import MovieService from "../services/MovieService";
import { ref } from "vue";
export default {
  name: "movie-list",
  data() {
    return {
      movies: [],
      input: ref(""),
    };
  },
  created() {
    this.listMovies();
  },
  watch: {
    input: function (val) {
      this.listMovies(val);
    },
  },
  methods: {
    listMovies(query) {
      MovieService.list(query)
        .then((response) => {
          this.movies = response.data.movies;
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
};
</script>

<template>
  <input name="search" type="text" v-model="input" placeholder="Search..." />
  <div v-if="input && !movies.length">
    <p>No results found!</p>
  </div>
  <ul class="grid-x grid-margin-x">
    <li
      v-for="movie in movies"
      :key="movie.id"
      class="card cell medium-4 large-3"
    >
      <RouterLink
        :to="{ name: 'details', params: { id: `${movie.id}` } }"
        class="card-divider"
        >{{ movie.title }}</RouterLink
      >
      <p class="card-section">Category: {{ movie.categoryName || "-" }}</p>
      <p class="card-section">Release year: {{ movie.year }}</p>
      <p class="card-section">Rating: {{ movie.rating }}</p>
    </li>
  </ul>
</template>
