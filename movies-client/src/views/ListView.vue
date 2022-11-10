<script>
import MovieService from "../services/MovieService";
import { ref } from "vue";
export default {
  name: "movie-list",
  data() {
    return {
      movies: [],
      input: ref(""),
      categories: [],
      error: "",
      isLoading: false,
    };
  },
  created() {
    this.listMovies();
  },
  watch: {
    input(val) {
      this.listMovies(val, this.categories);
    },
    categories(val) {
      this.listMovies(this.input, val);
    },
  },
  methods: {
    listMovies(query, categories) {
      this.isLoading = true;
      MovieService.list(query, categories)
        .then((response) => {
          this.movies = response.data.movies;
          this.error = "";
        })
        .catch((e) => {
          this.error = e;
        })
        .finally(() => {
          this.isLoading = false;
        });
    },
  },
};
</script>

<template>
  <div>
    <input name="search" type="text" v-model="input" placeholder="Search..." />
    <label
      >Filter by category (use ctrl to select and deselect multiple
      categories)</label
    >
    <select multiple v-model="categories">
      <option value="History">History</option>
      <option value="Fantasy">Fantasy</option>
      <option value="Science Fiction">Science Fiction</option>
      <option value="Comedy">Comedy</option>
      <option value="Horror">Horror</option>
      <option value="Drama">Drama</option>
      <option value="Action">Action</option>
    </select>
  </div>

  <div v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else-if="error">
    <p>Couldn't access the API!</p>
    <button @click="listMovies(input, categories)" class="button">
      try again!
    </button>
  </div>
  <div v-else-if="input && !movies.length">
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
