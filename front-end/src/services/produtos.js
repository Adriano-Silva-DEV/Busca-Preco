import {http } from './config'

export default {

    /* listar:() => {

        return http.get('/todos/produtos/1')
    }, */

    buscar:(buscaCodigo) => {
        return http.get('/produto/'+buscaCodigo)
    }

}