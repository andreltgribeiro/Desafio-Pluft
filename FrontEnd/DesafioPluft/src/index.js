import React from 'react';
import { Text, View } from 'react-native';
import { createBottomTabNavigator, createAppContainer, createStackNavigator, createSwitchNavigator} from 'react-navigation';
import Login from './Pages/Usuarios/Login';
import ListarLojistas from './Pages/Usuarios/ListarLojistas';
import ListarClientes from './Pages/Usuarios/ListarClientes';
import CadastrarLojista from './Pages/Usuarios/CadastrarLojista';
import CadastrarCliente from './Pages/Usuarios/CadastrarCliente';
import CadastrarAdm from './Pages/Usuarios/CadastrarAd';
import ListaProdutos from './Pages/Produtos/ListaProdutos'
import AtualizarProdutos from './Pages/Produtos/AtualizarProdutos';
import CadastrarProdutos from './Pages/Produtos/CadastrarProdutos';
import ListaEstabelecimentos from './Pages/Estabelecimentos/ListaEstabelec';
import CadastrarEstabelec from './Pages/Estabelecimentos/CadastrarEstabelecimento';
import AtualizarEstabelec from './Pages/Estabelecimentos/AtualizarEstabelecimento';
import CadastrarAgendamentos from './Pages/Agendamentos/CadastrarAgendamento';
import ListarAgendamentos from './Pages/Agendamentos/ListarAgendamentos';
import ListarAgendamentosUserLogado from './Pages/Agendamentos/ListarMeusAgendamentos';
import HomeAdm from './Pages/Homes/HomeAdm';
import HomeCliente from './Pages/Homes/HomeCliente';
import HomeLojista from './Pages/Homes//HomeLojista';

const Autorizado = createStackNavigator({ Login });

const ClienteStack = createBottomTabNavigator(
  {
    HomeCliente,
    ListaProdutos,
    ListaEstabelecimentos,
    ListarAgendamentos,
    CadastrarAgendamentos,
    ListarAgendamentosUserLogado

  },
  {
    initialRouteName: "HomeCliente"
});

const LojistaStack = createBottomTabNavigator(
  {
    HomeLojista,
    ListaProdutos,
    CadastrarEstabelec,
    AtualizarEstabelec,
    CadastrarProdutos,
    AtualizarProdutos,
    ListaProdutos
  },
  {
    initialRouteName: "HomeLojista",
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
    HomeAdm,
    ListarLojistas,
    ListarClientes,
    CadastrarLojista,
    CadastrarAdm,
    CadastrarCliente,
  },
  {
    initialRouteName: "HomeAdm",
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

const MainNavigator = createBottomTabNavigator(
  {
    Login
  },
  {
    initialRouteName: "Login",
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
  }
);

//export default createAppContainer(MainNavigator);

export default createAppContainer(
  createSwitchNavigator(
    {
      AdministradorStack,
      LojistaStack,
      ClienteStack,
      MainNavigator,
      Autorizado
    },
    {
      initialRouteName: "Autorizado"
    }
  )
);