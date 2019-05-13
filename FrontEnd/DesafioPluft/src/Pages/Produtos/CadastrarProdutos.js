import React, { Component } from 'react';
import { StyleSheet, Text, Image, TextInput, View, TouchableOpacity, AsyncStorage, Alert } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import api from '../../services/api'

class CadastrarProdutos extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../../assets/img/add.png")}
        style={styles.tabNavigatorIconHome}
      />
    )
  };

  constructor(props) {
    super(props);
    this.state = {
      Titulo: '',
      Descricao: '',
      QtdEstoque: '',
      IdEstabelec: '',
      Preco: ''
    }
  }

  _cadastrar = async () => {

    if (this.state.Titulo == null || this.state.Titulo == '') {
      Alert.alert(
        "Erro",
        "Informe um Titulo",
        [
          { text: "Later", onPress: () => console.log("later pressed") },
          {
            text: "Cancel",
            onPress: () => console.log("Cancel Pressed"),
            style: "cancel"
          },
          { text: "OK", onPress: () => console.log("OK Pressed") }
        ],
        { cancelable: false }
      );
    } else {
      if (this.state.Descricao == null || this.state.Descricao == '') {
        Alert.alert(
          "Erro",
          "Informe uma Descrição",
          [
            { text: "Later", onPress: () => console.log("later pressed") },
            {
              text: "Cancel",
              onPress: () => console.log("Cancel Pressed"),
              style: "cancel"
            },
            { text: "OK", onPress: () => console.log("OK Pressed") }
          ],
          { cancelable: false }
        );
      } else {
        if (this.state.QtdEstoque == null || this.state.QtdEstoque == '') {
          Alert.alert(
            "Erro",
            "Informe uma quantidade para o estoque",
            [
              { text: "Later", onPress: () => console.log("later pressed") },
              {
                text: "Cancel",
                onPress: () => console.log("Cancel Pressed"),
                style: "cancel"
              },
              { text: "OK", onPress: () => console.log("OK Pressed") }
            ],
            { cancelable: false }
          );
        } else {
          if (this.state.IdEstabelec == null || this.state.IdEstabelec == '' || this.state.IdEstabelec == 0) {
            Alert.alert(
              "Erro",
              "Informe um id de Estabelecimento",
              [
                { text: "Later", onPress: () => console.log("later pressed") },
                {
                  text: "Cancel",
                  onPress: () => console.log("Cancel Pressed"),
                  style: "cancel"
                },
                { text: "OK", onPress: () => console.log("OK Pressed") }
              ],
              { cancelable: false }
            );
          } else {
            if (this.state.Preco == null || this.state.Preco == '' || this.state.Preco == 0) {
              Alert.alert(
                "Erro",
                "Informe um preço válido",
                [
                  { text: "Later", onPress: () => console.log("later pressed") },
                  {
                    text: "Cancel",
                    onPress: () => console.log("Cancel Pressed"),
                    style: "cancel"
                  },
                  { text: "OK", onPress: () => console.log("OK Pressed") }
                ],
                { cancelable: false }
              );
            } else {

              const value = await AsyncStorage.getItem("userToken");

              await api.post("/produtos", {
                Titulo: this.state.Titulo,
                Descricao: this.state.Descricao,
                QtdEstoque: this.state.QtdEstoque,
                IdEstabelec: this.state.IdEstabelec,
                Preco: this.state.Preco
              }, {
                  headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + value
                  },


                });
              Alert.alert(
                "Parabéns",
                "Você Cadastrou um Produto",
                [
                  { text: "Later", onPress: () => console.log("later pressed") },
                  {
                    text: "Cancel",
                    onPress: () => console.log("Cancel Pressed"),
                    style: "cancel"
                  },
                  { text: "OK", onPress: () => console.log("OK Pressed") }
                ],
                { cancelable: false }
              );
              this.props.navigation.navigate("AdministradorStack");
            }
          }
        }
      }
    }

  }


  render() {
    return (
      <View>
        <View style={styles.cabecalho}>
          <Text style={styles.titulo}>Cadastrar Produtos</Text>
          <View style={styles.linhaTitulo} />
        </View>
        <View style={styles.body}>
          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Título do Produto'
            onChangeText={Titulo => this.setState({ Titulo })}
            placeholderTextColor='rgb(161, 162, 163)' />

          <ScrollView>
            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Descrição'
              onChangeText={Descricao => this.setState({ Descricao })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Qtd de Estoque'
              onChangeText={QtdEstoque => this.setState({ QtdEstoque })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Id do estabelecimento'
              onChangeText={IdEstabelec => this.setState({ IdEstabelec })}
              placeholderTextColor='rgb(161, 162, 163)' />


            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Preço'
              onChangeText={Preco => this.setState({ Preco })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TouchableOpacity style={styles.buttonContainer}
              onPress={this._cadastrar}
            >
              <Text style={styles.buttonText}>Confirmar</Text>
            </TouchableOpacity>
          </ScrollView>
        </View>
      </View>
    );
  }
}
export default CadastrarProdutos;


const styles = StyleSheet.create({
  body: {
    justifyContent: 'center',
    alignItems: 'center'
  },
  tabNavigatorIconHome: {
    width: 25,
    height: 25,
    // tintColor: "purple"
    tintColor: "#FFFFFF"
  },
  container: {
    padding: 20
  },
  input: {
    height: 40,
    backgroundColor: 'rgba(225,225,225,0.2)',
    marginBottom: 10,
    padding: 10,
    color: 'black',
    width: 376
  },
  buttonContainer: {
    backgroundColor: 'rgb(94, 155, 255)',
    paddingVertical: 15,
    width: 376,
  },
  buttonText: {
    color: '#fff',
    textAlign: 'center',
    fontWeight: '700'
  },
  titulo: {
    fontSize: 16,
    letterSpacing: 1
  },
  cabecalho: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    marginTop: 30,
    marginBottom: 30
  },

  linhaTitulo: {
    width: 100,
    borderBottomColor: "#999999",
    borderBottomWidth: 0.9,
    marginBottom: 8,
    marginTop: 2
  }
});