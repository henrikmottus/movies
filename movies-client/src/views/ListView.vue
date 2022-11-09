<script>
import MovieService from "../services/MovieService";
export default {
  name: "movie-list",
  data() {
    return {
      movies: [],
    };
  },
  created() {
    this.listMovies();
  },

  methods: {
    listMovies() {
      MovieService.list()
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
