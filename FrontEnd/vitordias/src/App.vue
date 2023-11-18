<template>
  <div id="app">
    <header>
      <TheHeader />
    </header>
    <main>
      <TheMain />
    </main>
    <footer>
      <TheFooter/>
    </footer>
  </div>
</template>

<script>

import TheHeader from './components/TheHeader.vue';
import TheMain from './components/TheMain.vue';
import TheFooter from './components/TheFooter.vue';

export default {
  name: 'App',
  data() {
    return {
      // Dados do componente
    };
  },
  methods: {
    // Métodos do componente
  },
  computed: {
    // Propriedades computadas
  },
  components: {
    TheHeader,
    TheMain,
    TheFooter,
    TheFooter
},
};
</script>

<style scoped>
/* Estilos do componente */
</style>
