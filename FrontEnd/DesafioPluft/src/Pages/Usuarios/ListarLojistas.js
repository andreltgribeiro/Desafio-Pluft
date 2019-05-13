import React, { Component } from 'react';
import { StyleSheet, Text, Image, View, FlatList, AsyncStorage, ScrollView } from 'react-native';
import api from '../../services/api';

class ListarLojistas extends Component {
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
      ListaLojistas: []
    }
  }
  componentDidMount() {
    this.carregarLojistas();
  }

  carregarLojistas = async () => {
    const value = await AsyncStorage.getItem("userToken")
    const resposta = await api.get("/usuarios/lojistas", {
      headers: {
        "Content-Type": "application/json",
        "Authorization": "Bearer " + value
      }
    });
    const dadosDaApi = resposta.data;
    this.setState({ ListaLojistas: dadosDaApi });
  };

  render() {
    return (
      <View style={styles.main}>
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image
              source={require("../../assets/img/support.png")}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{"Lojistas".toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        <View style={styles.mainBody}>
          <ScrollView>
            <FlatList
              contentContainerStyle={styles.mainBodyConteudo}
              data={this.state.ListaLojistas}
              keyExtractor={item => item.id}
              renderItem={this.renderizaItem}
            />
          </ScrollView>
        </View>
      </View>
    );
  }

  renderizaItem = ({ item }) => (
    <View style={styles.flatItemLinha}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitulo}> Id: {item.id}</Text>
        <Text style={styles.flatItemData}>CPF: {item.cpf}</Text>
        <Text style={styles.flatItemData}>Data de Nascimento: {item.datanascimento}</Text>
        <Text style={styles.flatItemData}>Nome: {item.nome}</Text>
        <Text style={styles.flatItemData}>Email: {item.email}</Text>
        <Text style={styles.flatItemData}>Telefone: {item.telefone}</Text>
        <Text style={styles.flatItemData}>Endereço: {item.endereco}</Text>
        <Text style={styles.flatItemData}>Estabelecimento: {item.estabelecimento}</Text>
      </View>
    </View>
  );
}
export default ListarLojistas;

const styles = StyleSheet.create({
  tabNavigatorIconHome: {
    width: 25,
    height: 25,
    tintColor: "#FFFFFF"
  },
  main: {
    flex: 1,
    backgroundColor: "#F1F1F1"
  },
  mainHeaderRow: {
    flexDirection: "row"
  },
  mainHeader: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center"
  },
  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: "#cccccc",
    marginRight: -9,
    marginTop: -9
  },
  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: "#999999",
    fontFamily: "OpenSans-Regular"
  },
  mainHeaderLine: {
    width: 170,
    paddingTop: 10,
    borderBottomColor: "#999999",
    borderBottomWidth: 0.9
  },
  mainBody: {
    flex: 4
  },
  mainBodyConteudo: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50
  },
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