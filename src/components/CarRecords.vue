<template>
  <div class="container-fluid mt-4">
    <h1 class="h1">Cars</h1>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-row>
      <b-col>
        <table class="table table-striped">
          <thead>
            <tr>
              <th>ID</th>
              <th>Model</th>
              <th>DateProduced</th>
              <th>Price</th>
              <th>&nbsp;</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="record in records" :key="record.id">
              <td>{{ record.id }}</td>
              <td>{{ record.model }}</td>
              <td>{{ record.produced }}</td>
              <td>{{ record.price }}</td>
              <td class="text-right">
                <a href="#" @click.prevent="updateCarRecord(record)">Edit</a> -
                <a href="#" @click.prevent="deleteCarRecord(record.id)">Delete</a>
              </td>
            </tr>
          </tbody>
        </table>
      </b-col>
      <b-col lg="3">
        <b-card :title="(model.id ? 'Edit Car ID#' + model.id : 'New Car')">
          <form @submit.prevent="createCarRecord">
            <b-form-group label="Model">
              <b-form-input type="text" v-model="model.model"></b-form-input>
            </b-form-group>
            <b-form-group label="Price">
              <b-form-input rows="4" v-model="model.price" type="number"></b-form-input>
            </b-form-group>
            <b-form-group label="DateProduced">
              <b-form-input rows="4" v-model="model.produced" type="text"></b-form-input>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save Record</b-btn>
            </div>
          </form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
  import api from '@/CarsOverviewApiService';

  export default {
    data() {
      return {
        loading: false,
        records: [],
        model: {}
      };
    },
    async created() {
      this.getAll()
    },
    methods: {
      async getAll() {
        this.loading = true

        try {
          this.records = await api.getAll()
        } finally {
          this.loading = false
        }
      },
      async updateCarRecord(car) {
        this.model = Object.assign({}, car)
      },
      async createCarRecord() {
        const isUpdate = !!this.model.id;

        if (isUpdate) {
          await api.update(this.model.id, this.model)
        } else {
          await api.create(this.model)
        }

        // Clear the data inside of the form
        this.model = {}
        
        await this.getAll()
      },
      async deleteCarRecord(id) {
        if (confirm('Are you sure you want to delete this record?')) {
          if (this.model.id === id) {
            this.model = {}
          }

          await api.delete(id)
          await this.getAll()
        }
      }
    }
  }
</script>