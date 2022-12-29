package com.example.medicinereminderapp.api;

import com.example.medicinereminderapp.LoginActivity;
import com.example.medicinereminderapp.models.DetailPrescription;
import com.example.medicinereminderapp.models.Medicine;
import com.example.medicinereminderapp.models.User;
import com.example.medicinereminderapp.models.UserList;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.squareup.okhttp.OkHttpClient;

import java.security.cert.CertificateFactory;
import java.util.List;

import javax.net.ssl.HostnameVerifier;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Query;

public interface ApiService {
    Gson gson = new GsonBuilder()
            .setDateFormat("yyyy-MM-dd HH:mm:ss")
            .create();


    ApiService apiService = new Retrofit.Builder()
            .baseUrl("http://10.0.2.2:5000/api/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(ApiService.class);

    @POST("Users")
    Call<User> insertUser(@Body User user);

    @GET("Users")
    Call<List<User>> getListUser();

    @GET("Medicines")
    Call<List<Medicine>> getListMedicine();

    @GET("DetailPrescription")
    Call<List<DetailPrescription>> getListDetailPrescription();


}
