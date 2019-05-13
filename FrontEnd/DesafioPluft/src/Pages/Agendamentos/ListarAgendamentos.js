import React, { Component } from 'react';
import { Text, Image, StyleSheet, View, FlatList, AsyncStorage } from 'react-native';
import api from '../../services/api'

class ListarAgendamentos extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../../assets/img/list.png")}
        style={styles.tabNavigatorIconHome}
      />
    )
  };

  constructor(props) {
    super(props);
    this.state = {
      ListaAgendamentos: []
    }
  }

  componentDidMount() {
    this.carregarAgendamentos();
  }

  carregarAgendamentos = async () => {
    const value = await AsyncStorage.getItem("userToken");
    const resposta = await api.get("/agendamentos", {
      headers: {
        "Content-Type": "application/json",
        "Authorization": "Bearer " + value
      }
    });
    const dadosDaApi = resposta.data;
    this.setState({ ListaAgendamentos: dadosDaApi });
  };
  render() {
    return (
      <View style={styles.main}>
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image
              source={require("../../assets/img/calendar.png")}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{"Agendamentos".toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>
        <View style={styles.mainBody}>
          <FlatList
            contentContainerStyle={styles.mainBodyConteudo}
            data={this.state.ListaAgendamentos}
            keyExtractor={item => item.id}
            renderItem={this.renderizaItem}
          />
        </View>
      </View>
    );
  }

  renderizaItem = ({ item }) => (
    <View style={styles.flatItemLinha}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitulo}>Id: {item.id}</Text>
        <Text style={styles.flatItemData}>CPF Cliente: {item.clienteCpf}</Text>
        <Text style={styles.flatItemData}>Nome Cliente: {item.nomecliente}</Text>
        <Text style={styles.flatItemData}>RG: {item.clienterg}</Text>
        <Text style={styles.flatItemData}>Endereço Cliente: {item.clienteendereco}</Text>
        <Text style={styles.flatItemData}>Nome Lojista{item.nomelojista}</Text>
        <Text style={styles.flatItemData}>Data do Agendamento{item.dataagendamento}</Text>
        <Text style={styles.flatItemData}>Data da Criação{item.datacriacao}</Text>
        <Text style={styles.flatItemData}>Status do Agendamento{item.statusagendamento}</Text>
      </View>
    </View>
  );
}
export default ListarAgendamentos;

const styles = StyleSheet.create({
  tabNavigatorIconHome: {
    width: 25,
    height: 25,
    // tintColor: "purple"
    tintColor: "#FFFFFF"
  },
  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: "#F1F1F1"
  },
  // cabecalho
  mainHeaderRow: {
    flexDirection: "row"
  },
  mainHeader: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center"
  },
  // imagem do cabeçalho
  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: "#cccccc",
    marginRight: -9,
    marginTop: -9
  },
  // texto do cabecalho
  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: "#999999",
    fontFamily: "OpenSans-Regular"
  },
  // linha de separacao do cabecalho
  mainHeaderLine: {
    width: 170,
    paddingTop: 10,
    borderBottomColor: "#999999",
    borderBottomWidth: 0.9
  },
  // corpo do texto
  mainBody: {
    // backgroundColor: "#999999",
    flex: 4
  },
  // conteúdo da lista
  mainBodyConteudo: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50
  },
  // dados do evento de cada item da linha
  flatItemLinha: {
    flexDirection: "row",
    borderBottomWidth: 0.9,
    borderBottomColor: "gray"
  },
  flatItemContainer: {
    flex: 7,
    marginTop: 5
  },
  flatItemTitulo: {
    fontSize: 14,
    color: "#333",
    fontFamily: "OpenSans-Light"
  },
  flatItemData: {
    fontSize: 10,
    color: "#999",
    lineHeight: 24
  },
  flatItemImg: {
    justifyContent: "center",
    alignContent: "center",
    alignItems: "center"
  },
  flatItemImgIcon: {
    width: 22,
    height: 22,
    tintColor: "#B727FF"
  }
});