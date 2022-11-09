<script>
import MovieService from "../services/MovieService";
export default {
  name: "movie-details",
  data() {
    return {
      movie: {},
    };
  },
  created() {
    this.getById(this.$route.params.id);
  },

  methods: {
    getById(id) {
      MovieService.getById(id)
        .then((response) => {
          this.movie = response.data;
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
};
</script>

<template>
  <h2 class="text-center">{{ movie.title }}</h2>
  <p>Release date: {{ movie.year }}</p>
  <p>Rating: {{ movie.rating }}</p>
  <p>{{ movie.description }}</p>
</template>
