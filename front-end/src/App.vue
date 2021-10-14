<template>
  <div id="app">
    <!--  <tr v-for= "produto of produtos" :key="produto.codigoreduzido">
        <td>{{ produto.codbarras }} </td>
        <td>{{ produto.codigoreduzido }} </td>
        <td>{{ produto.nomefantasia }} </td>
        <td>{{ produto.preco01 }} </td>
       </tr>
      -->

    <div class="container-sm m-5 rounded">
      <header>
        <img class="rounded mx-auto d-block" :src="logo" />
      </header>

      <div class="row justify-content-center body rounded">
        <div class="col-8 mb-4">
          <form @submit.prevent="buscar">
            <div class="mb-3">
              <label class="form-label"></label>
              <input
                type="text"
                class="form-control"
                aria-describedby=""
                v-model="buscaCodigo"
              />
              <div id="emailHelp" class="form-text">
                Leia um código de Barras
              </div>
            </div>

            <!-- <button type="Buscar" class="btn btn-danger">Buscar</button> -->
          </form>
        </div>

        <div class="col-8 area-produto m-5" v-if="areaAtiva">
          <h6>Código: {{ produto.codigoreduzido }}</h6>
                      <h1>{{ produto.nomefantasia }}</h1>
                      <div class="preco text-right">  R${{produto.precO1.toString().replace(".", ",")}} Reais</div>
        </div>
      </div>

      <footer v-if="!areaAtiva">
        <h1 class="busca-preço text-center">BUSCA PREÇO</h1>
      </footer>
   
    </div>
  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
import Produto from "./services/produtos";
import logo from "./assets/logo.png";

export default {
  name: "App",
  components: {
    // HelloWorld
  },

  data() {
    return {
      areaAtiva: false,
      buscaCodigo: [],
      produto: [],
      logo: logo,
    };
  },

  methods: {
    esconderArea() {
      this.areaAtiva = false;
      this.produto = [];
    },

    buscar() {
      Produto.buscar(this.buscaCodigo).then((resposta) => {
        //alert(resposta.data.precO1);
        this.buscaCodigo = null;
        this.produto = resposta.data;
        this.areaAtiva = true;
        setTimeout(this.esconderArea, 10000);
      });
    },
  },

  mounted() {
    Produto.listar().then((resposta) => {
      console.log(resposta.data);
      this.produto = resposta.data;
    });
  },
};
</script>

<style>
body {
  background: black !important;
}
header, footer {
   color: white;
}
.busca-preço{
font-size: 100px;
 animation: blinker 1s linear infinite;
}
.body {
  background: white;
}

@keyframes blinker {
  50% {
    opacity: 0;
  }
}
.preco{
font-size: 80px;
color: red;
font-weight: bold;;

}
</style>
