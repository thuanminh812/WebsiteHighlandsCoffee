<template>
  <div>
    <HomePage />
    <br>
    <br>
    <br>
    <div class="container">
      <div class="row">
        <div class="col-sm-3">
          <h2 style="font-weight: bold;">BẢNG TIN</h2>
        </div>     
        <div class="justify-content-end col-sm-4">
          <form action="" class="form-inline">
            <div class="form-group">
              <label for="" style="font-size:20px;font-weight: bold;">Tìm kiếm:</label>
              <input placeholder="Tìm kiếm" type="text" class="form-control ml-2 mr-2" name="tim" v-model="search">
            </div>
          </form>
        </div>
        <div class=" col-sm-5">
          <form action="" class="form-inline">
          <div class="form-group">
          <label for="category" style="font-size:20px;font-weight: bold;"><i class="fa-solid fa-filter"></i> </label>
        <select id="category" class="form-control ml-2" v-model="selectedCategory" @change="filterTinTucByCategory">
          <option value="">Tất cả</option>
          <option v-for="danhmuctintuc in danhmuctintucs" :value="danhmuctintuc.tinTucId" :key="danhmuctintuc.tinTucId">{{ danhmuctintuc.tenDanhMuc }}</option>
        </select>
      </div>
      </form>
        </div>
      </div>
      <hr>
      <div>
      </div>
      <hr>
      <div v-for="tintuc in filteredTinTuc" :key="tintuc.id">
        <router-link :to="{ name: 'tintucchitiet', params: {id: tintuc.id}}" class="text-dark">
          <div class="row">
            <div class="col-sm-3">
              <v-img :src="tintuc.hinhAnh"></v-img>       
            </div>
            <div class="col-sm-6">
              <h4 style="font-weight: bold;">{{ tintuc.tieuDe }}</h4>
              <p class="text-left"><i class="fa-regular fa-calendar"></i> Ngày đăng: {{ tintuc.ngayTao }}</p>
              <h6>{{ tintuc.linkUrl }}</h6>
            </div>
          </div>
        </router-link>
        <br>
      </div>
    </div>
    <br>
  </div>
</template>

<script>
import axios from 'axios';
import HomePage from '../components/HomePage.vue';

export default {
  name: 'TinTuc',
  components: {
    HomePage,
  },
  data() {
    return {
      tintucs: [],
      search: '',
      tintuc: {
        tieuDe: '',
        moTaTinTuc: '',
        ngayTao: '',
        linkUrl: '',
      },
      selectedCategory: '',
      danhmuctintucs: [],
    };
  },
  computed: {
    filteredTinTuc() {
    if (this.selectedCategory !== '') {
      return this.tintucs.filter(tintuc => {
        return (
          tintuc.tinTucId === this.selectedCategory &&
          this.matchesSearch(tintuc)
        );
      });
    } else {
      return this.tintucs.filter(tintuc => {
        return this.matchesSearch(tintuc);
      });
    }
  },

  },
  created() {
    let id = this.$route.params.id;
    if (id) {
      this.getTinTuc(id);
    }
  },
  mounted() {
    axios.get('https://localhost:7096/api/DanhMucTinTuc')
      .then(response => {
        if (response.data) {
          this.danhmuctintucs = response.data;
        }
      })
      .catch(e => {
        console.log("Lỗi", e);
      });

    axios.get('https://localhost:7096/api/TinTuc')
      .then(response => {
        if (response.data) {
          this.tintucs = response.data;
        }
      })
      .catch(e => {
        console.log("Lỗi", e);
      });
  },
  methods: {
    getTinTuc(id) {
      axios.get(`https://localhost:7096/api/TinTuc/tintucid/${id}`).then(response => {
        this.tintuc = response.data;
      });
    },
    matchesSearch(tintuc) {
      const searchTerm = this.search.toLowerCase();
  return tintuc.tieuDe.toLowerCase().includes(searchTerm);
    },
    filterTinTucByCategory() {
      this.search = ''; // Reset search when category changes
    },
  },
};
</script>

<style>

</style>
