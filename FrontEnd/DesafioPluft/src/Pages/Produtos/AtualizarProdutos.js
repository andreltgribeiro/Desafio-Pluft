import React, { Component } from 'react';
import { StyleSheet, Text, Image, TextInput, View, TouchableOpacity, AsyncStorage, Alert } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';
import api from '../../services/api'

class AtualizarProdutos extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../../assets/img/refresh.png")}
        style={styles.tabNavigatorIconHome}
      />
    )
  };

  constructor(props) {
    super(props);
    this.state = {
      id: '',
      titulo: '',
      descricao: '',
      qtdEstoque: '',
      idEstabelec: '',
      preco: ''
    }
  }

  _Atualizar = async () => {
    if (this.state.id == null || this.state.id == '' || this.state.id == 0) {
      Alert.alert(
        "Erro",
        "Informe um Id Válido",
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

      if (this.state.titulo == null || this.state.titulo == '') {
        Alert.alert(
          "Erro",
          "Informe um título",
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
        if (this.state.descricao == null || this.state.descricao == '') {
          Alert.alert(
            "Erro",
            "Informe uma descirção",
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
          if (this.state.qtdEstoque == null || this.state.qtdEstoque == '') {
            Alert.alert(
              "Erro",
              "Informe uma nova quantidade de estoque",
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
            if (this.state.idEstabelec == null || this.state.idEstabelec == '' || this.state.idEstabelec == 0) {
              Alert.alert(
                "Erro",
                "Informe um id de estabelecimento do qual seu produto pertence",
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
              if (this.state.preco == null || this.state.preco == '') {
                Alert.alert(
                  "Erro",
                  "Informe um novo preço para seu produto",
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

                  await api.put("/produtos", {
                    id: this.state.id,
                    titulo: this.state.titulo,
                    descricao: this.state.descricao,
                    qtdEstoque: this.state.qtdEstoque,
                    idEstabelec: this.state.idEstabelec,
                    preco: this.state.preco
                  }, {
                      headers: {
                        "Content-Type": "application/json",
                        "Authorization": "Bearer " + value
                      },


                    });
                  Alert.alert(
                    "Parabéns",
                    "Você Cadastrou um Estabelecimento",
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
                
              }
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
          <Text style={styles.titulo}>Atualizar Estabelecimento</Text>
          <View style={styles.linhaTitulo} />
        </View>
        <View style={styles.body}>
          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Id do Produto que deseja atualizar'
            onChangeText={id => this.setState({ id })}
            placeholderTextColor='rgb(161, 162, 163)' />


          <TextInput style={styles.input}
            autoCapitalize="none"
            returnKeyType="next"
            placeholder='Novo Nome do produto'
            onChangeText={titulo => this.setState({ titulo })}
            placeholderTextColor='rgb(161, 162, 163)' />


          <ScrollView>
            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Nova Descrição do produto)'
              onChangeText={descricao => this.setState({ descricao })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Nova quantidade de estoque do produto'
              onChangeText={qtdEstoque => this.setState({ qtdEstoque })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Novo Id de estabelecimento do qual o produto pertence'
              onChangeText={idEstabelec => this.setState({ idEstabelec })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TextInput style={styles.input}
              autoCapitalize="none"
              returnKeyType="next"
              placeholder='Novo Preço'
              onChangeText={preco => this.setState({ preco })}
              placeholderTextColor='rgb(161, 162, 163)' />

            <TouchableOpacity style={styles.buttonContainer}
              onPress={this._Atualizar}
            >
              <Text style={styles.buttonText}>Confirmar</Text>
            </TouchableOpacity>
          </ScrollView>
        </View>
      </View>
    );
  }
}
export default AtualizarProdutos;


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