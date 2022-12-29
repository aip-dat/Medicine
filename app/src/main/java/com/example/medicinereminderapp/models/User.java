package com.example.medicinereminderapp.models;

import java.io.Serializable;

public class User implements Serializable {
    private String idUser;
    private String nameUser;
    private String passwordUser;
    private String fullNameUser;
    private String emailUser;
    private String imageUrlUser;

    @Override
    public String toString() {
        return "User{" +
                "idUser='" + idUser + '\'' +
                ", nameUser='" + nameUser + '\'' +
                ", passwordUser='" + passwordUser + '\'' +
                ", fullNameUser='" + fullNameUser + '\'' +
                ", emailUser='" + emailUser + '\'' +
                ", imageUrlUser='" + imageUrlUser + '\'' +
                '}';
    }

    public String getIdUser() {
        return idUser;
    }

    public void setIdUser(String idUser) {
        this.idUser = idUser;
    }

    public String getNameUser() {
        return nameUser;
    }

    public void setNameUser(String nameUser) {
        this.nameUser = nameUser;
    }

    public String getPasswordUser() {
        return passwordUser;
    }

    public void setPasswordUser(String passwordUser) {
        this.passwordUser = passwordUser;
    }

    public String getFullNameUser() {
        return fullNameUser;
    }

    public void setFullNameUser(String fullNameUser) {
        this.fullNameUser = fullNameUser;
    }

    public String getEmailUser() {
        return emailUser;
    }

    public void setEmailUser(String emailUser) {
        this.emailUser = emailUser;
    }

    public String getImageUrlUser() {
        return imageUrlUser;
    }

    public void setImageUrlUser(String imageUrlUser) {
        this.imageUrlUser = imageUrlUser;
    }
}
