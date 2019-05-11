import React, {Component} from 'react';
import {
    StyleSheet,
    View,
    Text,
    Image,
    ImageBackground,
    TextInput,
    TouchableOpacity,
    AsyncStorage, Alert
  } from "react-native";
  import api from '../../services/api';
  import jwt from 'jwt-decode'




class Login extends Component{
    static navigationOptions = {
        header: null
      };
    
      constructor(props){
        super(props);
        this.state ={
            email: "",
            senha: ""
        }

        
    }

    login = async () => {
        if(this.state.email == ''){
            Alert.alert(
                "Erro",
                "Informe um email",
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
        if(this.state.senha == ''){
            Alert.alert(
                "Erro",
                "Informe sua senha",
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
        }else{
            const resposta = await api.post("/Login", {
                email: this.state.email,
                senha: this.state.senha
              });
              const token = resposta.data.token;
              await AsyncStorage.setItem("userToken", token);
              if(jwt(token).Role == 'Administrador'){
                this.props.navigation.navigate("homeadm");
              }
              if(jwt(token).Role == 'Cliente'){
                this.props.navigation.navigate("ClienteStack");
                }
                if(jwt(token).Role == 'Lojista'){
                    this.props.navigation.navigate("LojistaStack");
                }
        }
      };
      render() {
        return (
          <ImageBackground
            source={require("../../assets/img/login.png")}
            style={StyleSheet.absoluteFillObject}
          >
            <View style={styles.overlay} />
            <View style={styles.main}>
              <Image
                source={require("../../assets/img/loginIcon.png")}
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
        );
      }
}
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
export default Login;