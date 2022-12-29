package com.example.medicinereminderapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.medicinereminderapp.api.ApiService;
import com.example.medicinereminderapp.api.RetrofitClient;
import com.example.medicinereminderapp.models.User;
import com.example.medicinereminderapp.models.UserList;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {

    private EditText edtUsername, editPassword;
    private Button btnLogin;
    private TextView tvRegister;

    private List<User> mListUser;
    private User mUser;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        edtUsername = findViewById(R.id.edit_username);
        editPassword = findViewById(R.id.edit_password);
        btnLogin = findViewById(R.id.btn_login);
        tvRegister = findViewById(R.id.tv_register);


    }

    @Override
    protected void onStart() {
        super.onStart();
        mListUser = new ArrayList<>();
        getAllUser();

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                clickLogin();
            }
        });

        tvRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(LoginActivity.this, RegisterActivity.class);
                startActivity(intent);
            }
        });
    }

    private void clickLogin() {
        String strUsername = edtUsername.getText().toString().trim();
        String strPassword = editPassword.getText().toString().trim();

        if (mListUser == null || mListUser.isEmpty()) {
            return;
        }

        boolean isHasUser = false;

        for (User user : mListUser){
            if (strUsername.equals(user.getNameUser()) && strPassword.equals(user.getPasswordUser())) {
                isHasUser = true;
                mUser = user;
                break;
            }
        }

        if (isHasUser){
            Intent intent = new Intent(LoginActivity.this, MainActivity.class);
            Bundle bundle = new Bundle();
            bundle.putSerializable("obj_user", mUser);
            intent.putExtras(bundle);
            startActivity(intent);
        }else{
            Toast.makeText(LoginActivity.this, "Username or Password invalid!", Toast.LENGTH_SHORT).show();
        }
    }

    private void getAllUser(){

        ApiService.apiService.getListUser().enqueue(new Callback<List<User>>() {
            @Override
            public void onResponse(Call<List<User>> call, Response<List<User>> response) {
                mListUser = response.body();
                if (mListUser != null) {
                    Log.e("List Users", mListUser.size() + "");
                }
            }

            @Override
            public void onFailure(Call<List<User>> call, Throwable t) {
                Toast.makeText(LoginActivity.this, "Call Api Error!", Toast.LENGTH_SHORT).show();
            }
        });

    }




}