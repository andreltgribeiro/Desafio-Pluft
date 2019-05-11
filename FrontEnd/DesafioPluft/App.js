

import React, { Component } from 'react';
import { AsyncStorage, StyleSheet, Text, TextInput, View, ImageBackground,TouchableOpacity, Image, Alert } from 'react-native';

import api from './src/services/api';

import jwt from "jwt-decode";

import { createSwitchNavigator, createAppContainer, createDrawerNavigator, createBottomTabNavigator } from 'react-navigation';

import Login from './src/Pages/Usuarios/Login';
import ListarLojistas from './src/Pages/Usuarios/ListarLojistas';
import ListarClientes from './src/Pages/Usuarios/ListarClientes';
import CadastrarLojista from './src/Pages/Usuarios/CadastrarLojista';
import CadastrarCliente from './src/Pages/Usuarios/CadastrarCliente';
import CadastrarAdm from './src/Pages/Usuarios/CadastrarAd';
import ListaProdutos from './src/Pages/Produtos/ListaProdutos'
import AtualizarProdutos from './src/Pages/Produtos/AtualizarProdutos';
import CadastrarProdutos from './src/Pages/Produtos/CadastrarProdutos';
import ListaEstabelecimentos from './src/Pages/Estabelecimentos/ListaEstabelec';
import CadastrarEstabelec from './src/Pages/Estabelecimentos/CadastrarEstabelecimento';
import AtualizarEstabelec from './src/Pages/Estabelecimentos/AtualizarEstabelecimento';
import CadastrarAgendamentos from './src/Pages/Agendamentos/CadastrarAgendamento';
import ListarAgendamentos from './src/Pages/Agendamentos/ListarAgendamentos';
import ListarAgendamentosUserLogado from './src/Pages/Agendamentos/ListarMeusAgendamentos';
import HomeAdm from './src/Pages/Homes/HomeAdm';
import HomeCliente from './src/Pages/Homes/HomeCliente';
import HomeLojista from './src/Pages/Homes//HomeLojista';




class App extends Component {

  render() {
      return (
          <AppContainer />
      )
  }
}

export default App;

class TelaInicial extends Component {

  constructor(props) {
      super(props);
      this.state = { email : '', senha : '' };
  }


  login = async () => {
    if(this.state.email == ''){
        Alert.alert(
            "Erro",
            "Informe um email",
            [
              
              { text: "OK", onPress: () => console.log("OK Pressed") }
            ],
            { cancelable: false }
          );
    }else{

      if(this.state.senha == ''){
        Alert.alert(
          "Erro",
          "Informe sua senha",
          [
            { text: "OK", onPress: () => console.log("OK Pressed") }
          ],
          { cancelable: false }
          );
        }else{
          const resposta = await api.post("/Login", {
            email: this.state.email,
            senha: this.state.senha
          });
          const token = resposta.data.token;
          await AsyncStorage.setItem("userToken", token);
          if ( jwt(token).permissao == 'Administrador' ) {
            this.props.navigation.navigate('Home - Administrador')            
          }
          if ( jwt(token).permissao == 'Cliente' ) {
            this.props.navigation.navigate('Home - Cliente')            
          }if(jwt(token).permissao == 'Lojista'){
            this.props.navigation.navigate('Home - Lojista')     
          }
        }
      }
      };

  

  render() {
      return (
        <ImageBackground
        source={require("./src/assets/img/login.png")}
        style={StyleSheet.absoluteFillObject}
      >
        <View style={styles.overlay} />
        <View style={styles.main}>
          <Image
            source={require("./src/assets/img/loginIcon.png")}
            style={styles.mainImgLogin}
          />
          <TextInput
            style={styles.inputLogin}
            placeholder="email"
            placeholderTextColor="#FFFFFF"
            underlineColorAndroid="#FFFFFF"
            required
            onChangeText={email => this.setState({ email })}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="senha"
            placeholderTextColor="#FFFFFF"
            password="true"
            underlineColorAndroid="#FFFFFF"
            onChangeText={senha => this.setState({ senha })}
          />
          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.login}
          >
            <Text style={styles.btnLoginText}>LOGIN</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
      )
  }
}

const ClienteStack = createBottomTabNavigator(
  {
    'Home - Cliente':HomeCliente,
    'Lista Produtos':ListaProdutos,
    'Lista Estabelecimento':ListaEstabelecimentos,
    'Lista Agendamentos':ListarAgendamentos,
    'Cadastra Agendamento':CadastrarAgendamentos,
    'Lista Meus Agendamentos':ListarAgendamentosUserLogado

  },
  {
    initialRouteName: "Home - Cliente",
    swipeEnabled: true,
    tabBarOptions: {
      showLabel: false,
      showIcon: true,
      inactiveBackgroundColor: "#83b1fc",
      activeBackgroundColor: "rgb(94, 155, 255)",
      activeTintColor: "#FFFFFF",
      inactiveTintColor: "#FFFFFF",
      style: {
        height: 50
      }
    }
});

const LojistaStack = createBottomTabNavigator(
  {
    'Home - Lojista':HomeLojista,
    'Lista Produtos':ListaProdutos,
    'Cadastra Estabelecimento':CadastrarEstabelec,
    'Atualiza Estabelecimento':AtualizarEstabelec,
    'Cadastra Produtos':CadastrarProdutos,
    'Atualiza Prodtos':AtualizarProdutos,
    'Lista Produtos':ListaProdutos
  },
  {
    initialRouteName: "Home - Lojista",
    swipeEnabled: true,
    tabBarOptions: {
      showLabel: false,
      showIcon: true,
      inactiveBackgroundColor: "#83b1fc",
      activeBackgroundColor: "rgb(94, 155, 255)",
      activeTintColor: "#FFFFFF",
      inactiveTintColor: "#FFFFFF",
      style: {
        height: 50
      }
    }
});

const AdministradorStack = createBottomTabNavigator(
  {
    'Tela Inicial': { screen: TelaInicial },
    'Home - Administrador': HomeAdm,
    'Listar Lojistas':ListarLojistas,
    'Listar Clientes':ListarClientes,
    'CadastrarLojista':CadastrarLojista,
    'CastrarAdm':CadastrarAdm,
    'CadastrarCliente':CadastrarCliente,

  },
  {
    initialRouteName: "Home - Administrador",
    swipeEnabled: true,
    tabBarOptions: {
      showLabel: false,
      showIcon: true,
      inactiveBackgroundColor: "#83b1fc",
      activeBackgroundColor: "rgb(94, 155, 255)",
      activeTintColor: "#FFFFFF",
      inactiveTintColor: "#FFFFFF",
      style: {
        height: 50
      }
    }
});





const AppSwitchNavigator = createSwitchNavigator({
  'Tela inicial': { screen: TelaInicial },
  'Home - Administrador': { screen: AdministradorStack },
  'Home - Cliente': { screen: ClienteStack },
  'Home - Lojista': { screen : LojistaStack}
})

const AppContainer = createAppContainer(AppSwitchNavigator);

const styles = StyleSheet.create({
  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: "rgb(94, 155, 255)"
  },
  main: {
    width: "100%",
    height: "100%",
    justifyContent: "center",
    alignContent: "center",
    alignItems: "center"
  },
  mainImgLogin: {
    tintColor: "#FFFFFF",
    height: 100,
    width: 90,
    margin: 10
  },
  btnLogin: {
    height: 38,
    shadowColor: "rgba(0,0,0, 0.4)", // IOS
    shadowOffset: { height: 1, width: 1 }, // IOS
    shadowOpacity: 1, // IOS
    shadowRadius: 1, //IOS
    elevation: 3, // Android
    width: 240,
    borderRadius: 4,
    borderWidth: 1,
    borderColor: "#FFFFFF",
    backgroundColor: "#FFFFFF",
    justifyContent: "center",
    alignItems: "center",
    marginTop: 10
  },
  btnLoginText: {
    fontSize: 10,
    fontFamily: "OpenSans-Light",
    color: "#5e9bff",
    letterSpacing: 4
  },
  inputLogin: {
    width: 240,
    marginBottom: 10,
    fontSize: 10
  }
});
