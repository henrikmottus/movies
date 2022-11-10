<script>
import MovieService from "../services/MovieService";
export default {
  name: "movie-details",
  data() {
    return {
      movie: {},
      error: "",
      isLoading: false,
    };
  },
  created() {
    this.getById(this.$route.params.id);
  },

  methods: {
    getById(id) {
      this.isLoading = true;
      MovieService.getById(id)
        .then((response) => {
          this.movie = response.data;
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
  <div v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else-if="error">
    <p>Couldn't access the API!</p>
    <button @click="getById(this.$route.params.id)" class="button">
      try again!
    </button>
  </div>
  <div v-else-if="!movie">
    <p>Movie not found, please return to the list page and try again!</p>
  </div>
  <div v-else>
    <h2 class="text-center">{{ movie.title }}</h2>
    <p>Release date: {{ movie.year }}</p>
    <p>Rating: {{ movie.rating }}</p>
    <p>{{ movie.description }}</p>
  </div>
</template>
